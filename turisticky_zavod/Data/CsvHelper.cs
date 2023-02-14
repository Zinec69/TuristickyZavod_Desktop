using System.Text;

namespace turisticky_zavod.Data
{
    public static class CsvHelper
    {
        public static List<Runner> LoadRunners(string filepath)
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
                        ID = !string.IsNullOrEmpty(line[0]) ? int.Parse(line[0]) : null,
                        LastName = line[1],
                        FirstName = line[2],
                        BirthYear = int.TryParse(line[3], out int result) ? result : 0,
                        Team = line[4],
                        Partner = string.IsNullOrEmpty(line[5]) ? null : new Runner()
                        {
                            LastName = line[5],
                            FirstName = line[6],
                            BirthYear = int.TryParse(line[7], out int result2) ? result2 : 0,
                            Team = line[8]
                        }
                    };
                    runners.Add(runner);
                }
            }

            return runners;
        }
    }
}
