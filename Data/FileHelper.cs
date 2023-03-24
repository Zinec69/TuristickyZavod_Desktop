using System.Text;
using System.Text.Json;

namespace turisticky_zavod.Data
{
    public static class FileHelper
    {
        public static List<Runner> LoadFromCSV(string filepath)
        {
            List<Runner> runners = new();

            using (var reader = new StreamReader(filepath, Encoding.GetEncoding("iso-8859-2")))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine()?.Split(';');
                    var runner = new Runner()
                    {
                        RunnerID = !string.IsNullOrEmpty(line[0]) ? int.Parse(line[0]) : null,
                        LastName = line[1].Trim(),
                        FirstName = line[2].Trim(),
                        BirthYear = int.TryParse(line[3], out int result) ? result : null,
                        Team = line[4].Trim(),
                        Partner = string.IsNullOrEmpty(line[5]) ? null : new()
                        {
                            LastName = line[5].Trim(),
                            FirstName = line[6].Trim(),
                            BirthYear = int.TryParse(line[7], out int result2) ? result2 : null
                        }
                    };
                    runners.Add(runner);
                }
            }

            return runners;
        }

        public static List<Runner> LoadFromJSON(string filepath)
        {
            List<Runner> runners = new();

            using (var reader = new StreamReader(filepath, Encoding.GetEncoding("iso-8859-2")))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                };
                runners = JsonSerializer.Deserialize<List<Runner>>(reader.ReadToEnd(), options);
            }

            return runners;
        }

        public static void ExportToJSON(List<Runner> runners, string filepath)
        {
            using (var writer = new StreamWriter(filepath, Encoding.GetEncoding("iso-8859-2"), new FileStreamOptions() { Mode = FileMode.Create }))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                };
                writer.Write(JsonSerializer.Serialize(runners, options));
            }
        }
    }
}
