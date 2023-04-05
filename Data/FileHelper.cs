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
            var database = Database.Instance;

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
                            Team = database.ChangeTracker.Entries<Team>()
                                                         .FirstOrDefault(x => x.Entity.Name == line[4].Trim(), null)?.Entity
                                                          ?? new() { Name = line[4].Trim() }
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
                        database.Runner.Local.Add(runner);
                    }
                }
            }

            return runners;
        }

        public static List<Runner> LoadRunnersFromJSON(string filepath)
        {
            var runners = new List<Runner>();

            using (var reader = new StreamReader(filepath, Encoding.GetEncoding("Windows-1250")))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters =
                    {
                        new RefereeJsonConverter(),
                        new CheckpointJsonConverter(),
                        new DateTimeJsonConverter(),
                        new TimeSpanJsonConverter(),
                        new TeamJsonConverter()
                    }
                };
                runners = JsonSerializer.Deserialize<List<Runner>>(reader.ReadToEnd(), options);
            }

            return runners;
        }

        public static AllData LoadEverythingFromJSON(string filepath)
        {
            using var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(fs, Encoding.GetEncoding("Windows-1250"));

            return JsonSerializer.Deserialize<AllData>(reader.ReadToEnd())!;
        }

        public static void ExportEverythingToJSON(AllData allData, string filepath)
        {
            using (var fs = new FileStream(filepath, FileMode.Create))
            {
                using (var writer = new StreamWriter(fs, Encoding.GetEncoding("Windows-1250")))
                {
                    var options = new JsonSerializerOptions
                    {
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        WriteIndented = true,
                        Converters = { new RunnerJsonConverter() }
                    };
                    writer.Write(JsonSerializer.Serialize(allData, options));
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

        public override void Write(Utf8JsonWriter writer, Checkpoint value, JsonSerializerOptions options) { }
    }

    internal class TeamJsonConverter : JsonConverter<Team>
    {
        public override Team Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var name = reader.GetString();
            var team = Database.Instance.ChangeTracker.Entries<Team>().FirstOrDefault(x => x.Entity.Name == name, null)?.Entity;
            team ??= Database.Instance.Team.ToList().FirstOrDefault(x => x.Name == name, null) ?? new() { Name = name };

            return team;
        }

        public override void Write(Utf8JsonWriter writer, Team value, JsonSerializerOptions options)
            => writer.Flush();// .WriteStringValue(value.Name);
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

    internal class RunnerJsonConverter : JsonConverter<Runner>
    {
        public override Runner Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new();

        public override void Write(Utf8JsonWriter writer, Runner value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteNumber(nameof(value.ID), value.ID);

            if (value.StartNumber.HasValue)
                writer.WriteNumber(nameof(value.StartNumber), value.StartNumber.Value);
            else
                writer.WriteNull(nameof(value.StartNumber));

            writer.WriteString(nameof(value.Name), value.Name);

            if (value.BirthYear.HasValue)
                writer.WriteNumber(nameof(value.BirthYear), value.BirthYear.Value);
            else
                writer.WriteNull(nameof(value.BirthYear));

            if (value.StartTime.HasValue)
                writer.WriteString(nameof(value.StartTime), value.StartTime.Value);
            else
                writer.WriteNull(nameof(value.StartTime));

            if (value.FinishTime.HasValue)
                writer.WriteString(nameof(value.FinishTime), value.FinishTime.Value);
            else
                writer.WriteNull(nameof(value.FinishTime));

            writer.WriteNumber(nameof(value.TeamID), value.TeamID);

            if (value.PartnerID.HasValue)
                writer.WriteNumber(nameof(value.PartnerID), value.PartnerID.Value);
            else
                writer.WriteNull(nameof(value.PartnerID));

            writer.WriteBoolean(nameof(value.Disqualified), value.Disqualified);

            if (value.AgeCategoryID.HasValue)
                writer.WriteNumber(nameof(value.AgeCategoryID), value.AgeCategoryID.Value);
            else
                writer.WriteNull(nameof(value.AgeCategoryID));

            writer.WriteStartArray(nameof(value.CheckpointInfo));

            foreach (var item in value.CheckpointInfo)
            {
                writer.WriteStartObject();

                writer.WriteNumber(nameof(item.ID), item.ID);
                writer.WriteNumber(nameof(item.Checkpoint.ID), item.Checkpoint.ID);
                writer.WriteString(nameof(item.TimeArrived), item.TimeArrived);

                if (item.TimeDeparted.HasValue)
                    writer.WriteString(nameof(item.TimeDeparted), item.TimeDeparted.Value);
                else
                    writer.WriteNull(nameof(item.TimeDeparted));

                writer.WriteString(nameof(item.TimeWaited), item.TimeWaited.ToString());
                writer.WriteString(nameof(item.Penalty), item.Penalty.ToString());

                writer.WriteEndObject();
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }
    }
}
