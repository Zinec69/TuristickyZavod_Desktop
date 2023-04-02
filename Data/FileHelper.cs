using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    public static class FileHelper
    {
        public static List<Runner> LoadFromCSV(string filepath)
        {
            List<Runner> runners = new();

            using (var reader = new StreamReader(filepath, Encoding.GetEncoding("Windows-1250")))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine()?.Split(';');
                    if (line != null && line.Length >= 5)
                    {
                        var runner = new Runner()
                        {
                            StartNumber = !string.IsNullOrEmpty(line[0].Trim()) ? int.Parse(line[0].Trim()) : null,
                            LastName = line[1].Trim(),
                            FirstName = line[2].Trim(),
                            BirthYear = int.TryParse(line[3].Trim(), out int result) ? result : null,
                            Team = new() { Name = line[4].Trim() }
                        };

                        if (line.Length >= 8)
                        {
                            runner.Partner = string.IsNullOrEmpty(line[5].Trim()) ? null : new()
                            {
                                LastName = line[5].Trim(),
                                FirstName = line[6].Trim(),
                                BirthYear = int.TryParse(line[7].Trim(), out int result2) ? result2 : null
                            };
                        }
                        else
                            runner.Partner = null;

                        if (line.Length >= 10 && AgeCategory.TryGetByString(line[9].Trim(), runner.Partner != null, out AgeCategory? category))
                        {
                            runner.AgeCategory = category;
                        }
                        else
                        {
                            runner.AgeCategory = runner.BirthYear.HasValue ? AgeCategory.GetByBirthYear(runner.BirthYear.Value, runner.Partner != null) : null;
                        }

                        runners.Add(runner);
                    }
                }
            }

            return runners;
        }

        public static List<Runner> LoadFromJSON(string filepath)
        {
            var runners = new List<Runner>();

            using (var reader = new StreamReader(filepath, Encoding.GetEncoding("ISO-8859-2")))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters =
                    {
                        new RefereeJsonConverter(),
                        new CheckpointJsonConverter(),
                        new DateTimeJsonConverter(),
                        new TimeSpanJsonConverter()
                    }
                };
                runners = JsonSerializer.Deserialize<List<Runner>>(reader.ReadToEnd(), options);
            }

            return runners;
        }

        public static void ExportToJSON(List<Runner> runners, string filepath)
        {
            using (var fs = new FileStream(filepath, FileMode.Create))
            {
                using (var writer = new StreamWriter(fs, Encoding.GetEncoding("ISO-8859-2")))
                {
                    var options = new JsonSerializerOptions
                    {
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        WriteIndented = true
                    };
                    writer.Write(JsonSerializer.Serialize(runners, options));
                }
            }
        }
    }

    internal class RefereeJsonConverter : JsonConverter<Referee>
    {
        public override Referee Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new() { Name = reader.GetString() };

        public override void Write(Utf8JsonWriter writer, Referee value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Name);
    }

    internal class CheckpointJsonConverter : JsonConverter<Checkpoint>
    {
        public override Checkpoint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var id = reader.GetInt32();
            return Database.Instance.Checkpoint.Single(c => c.ID == id);
        }

        public override void Write(Utf8JsonWriter writer, Checkpoint value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value.ID);
    }

    internal class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).DateTime.ToLocalTime();

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteNumberValue(new DateTimeOffset(value).ToUnixTimeMilliseconds());
    }

    internal class TimeSpanJsonConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new(0, 0, reader.GetInt32());

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value.TotalSeconds);
    }
}
