using ClosedXML.Excel;
using System.Text;
using System.Text.Json;

namespace turisticky_zavod.Data
{
    public static class FileHelper
    {
        public async static Task<List<Runner>> LoadFromCSV(string filePath)
        {
            List<Runner> runners = new();

            var database = Database.Instance;
            var allCategories = database.AgeCategory.Local;

            using (var reader = new StreamReader(filePath, Encoding.GetEncoding("Windows-1250")))
            {
                await reader.ReadLineAsync();
                while (!reader.EndOfStream)
                {
                    var line = (await reader.ReadLineAsync())?.Split(';');

                    if (line != null)
                    {
                        var startNumber = line[0].Trim();
                        var runner = new Runner()
                        {
                            StartNumber = !string.IsNullOrEmpty(startNumber) ? int.Parse(startNumber) : null,
                            LastName = line[1].Trim(),
                            FirstName = line[2].Trim(),
                            Gender = line[3].Trim().ToLower()[0] switch
                            {
                                'm' => Gender.MALE,
                                'f' or 'z' or 'ž' => Gender.FEMALE,
                                _ => throw new CsvException("Nepodařilo se přečíst pohlaví běžce z csv souboru")
                            },
                            Birthdate = DateTime.TryParse(line[4].Trim(), out DateTime birthday)
                                        ? birthday
                                        : throw new CsvException("Nepodařilo se přečíst datum narození běžce z csv souboru")
                        };

                        var teamName = line[5].Trim();
                        var team = database.ChangeTracker.Entries<Team>().FirstOrDefault(x => x.Entity.Name == teamName, null)?.Entity;
                        if (team == null)
                        {
                            runner.Team = new() { Name = teamName };
                            database.Team.Add(runner.Team);
                        }
                        else
                            runner.Team = team;

                        var partnerLastName = line[6].Trim();
                        runner.Partner = string.IsNullOrEmpty(partnerLastName) ? null : new()
                        {
                            LastName = partnerLastName,
                            FirstName = line[7].Trim(),
                            Gender = line[8].Trim().ToLower()[0] switch
                            {
                                'm' => Gender.MALE,
                                'f' or 'z' or 'ž' => Gender.FEMALE,
                                _ => throw new CsvException("Nepodařilo se přečíst pohlaví běžce z csv souboru")
                            },
                            Birthdate = DateTime.TryParse(line[9].Trim(), out DateTime birthday2)
                                        ? birthday2
                                        : throw new CsvException("Nepodařilo se přečíst datum narození běžce z csv souboru")
                        };

                        runner.AgeCategory = runner.Birthdate.HasValue
                            ? (runner.Partner == null
                                    ? (AgeCategory.TryGetByBirthdate(runner.Birthdate.Value, allCategories, runner.Gender, out AgeCategory? category) ? category : null)
                                    : (AgeCategory.TryGetByBirthdate(runner.Birthdate.Value, allCategories, runner.Gender, out AgeCategory? category2, CategoryType.DUOS,
                                            runner.Partner!.Birthdate.HasValue ? runner.Partner?.Birthdate.Value : null) ? category2 : null))
                            : null;

                        runners.Add(runner);
                    }
                    else
                        throw new CsvException("Nastala neočekávaná chyba při načítání csv souboru");
                }
            }

            return runners;
        }

        public static void ExportToExcel(List<Runner> runners, string filePath)
        {
            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Celkové výsledky");
            worksheet.Cell("B2").Value = $"Výsledky {DateTime.Now.Date:d.M.yyyy}";
            worksheet.Cell("B2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var partners = runners.Any(x => x.Partner != null);

            var cellRow = 4;
            var cellColumn = 'B';

            worksheet.Cell($"{cellColumn++}3").Value = "Umístění";
            worksheet.Cell($"{cellColumn++}3").Value = "Startovní číslo";
            worksheet.Cell($"{cellColumn++}3").Value = "Jméno";
            worksheet.Cell($"{cellColumn++}3").Value = "Příjmení";
            worksheet.Cell($"{cellColumn++}3").Value = "Oddíl";
            worksheet.Cell($"{cellColumn++}3").Value = "Datum narození";
            worksheet.Cell($"{cellColumn++}3").Value = "Věková kategorie";
            if (partners)
            {
                worksheet.Cell($"{cellColumn++}3").Value = "Jméno 2";
                worksheet.Cell($"{cellColumn++}3").Value = "Příjmení 2";
                worksheet.Cell($"{cellColumn++}3").Value = "Datum narození 2";
            }
            worksheet.Cell($"{cellColumn++}3").Value = "Výsledný čas";
            worksheet.Cell($"{cellColumn++}3").Value = "Celkový čas strávený čekáním";
            worksheet.Cell($"{cellColumn++}3").Value = "Celkový trestný čas";
            worksheet.Cell($"{cellColumn}3").Value = "Průměrný čas mezi stanovišti";

            worksheet.Range($"B2:{cellColumn}2").Merge();

            runners = runners.Where(x => !x.Disqualified && x.FinalRunTime.HasValue)
                             .OrderBy(x => x.FinalRunTime.Value).ToList()
                             .Concat(runners.Where(x => x.Disqualified || !x.FinalRunTime.HasValue)).ToList();

            var place = 1;
            foreach (var runner in runners)
            {
                cellColumn = 'B';

                worksheet.Cell($"{cellColumn++}{cellRow}").Value = place++;
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.StartNumber;
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.FirstName;
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.LastName;
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Team.ToString();
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Birthdate;
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.AgeCategory != null
                                                                    ? runner.AgeCategory.ToString()
                                                                    : string.Empty;
                if (partners)
                {
                    worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Partner != null
                                                                        ? runner.Partner!.FirstName
                                                                        : string.Empty;
                    worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Partner != null
                                                                        ? runner.Partner!.LastName
                                                                        : string.Empty;
                    worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Partner != null
                                                                        ? runner.Partner!.Birthdate
                                                                        : string.Empty;
                }
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.FinalRunTime.HasValue
                                                                    ? @$"{runner.FinalRunTime.Value:hh\:mm\:ss}"
                                                                    : string.Empty;
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = @$"{runner.TotalWaitTime:hh\:mm\:ss}";
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = @$"{runner.TotalPenaltyTime:hh\:mm\:ss}";
                worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.AverageTimeBetweenCheckpoints.HasValue && runner.AverageTimeBetweenCheckpoints.Value.TotalSeconds > 0
                                                                    ? @$"{runner.AverageTimeBetweenCheckpoints:hh\:mm\:ss)}"
                                                                    : "-";

                if (runner.Disqualified)
                {
                    var disqualificationCheckpoint = runner.CheckpointInfo.Find(x => x.Disqualified);
                    worksheet.Cell($"{cellColumn}{cellRow}").Value = $"Diskvalifikován/a na stanovišti {disqualificationCheckpoint!.Checkpoint.Name}";
                    worksheet.Range($"B{cellRow}:{(char)(cellColumn - 1)}{cellRow}").Style.Fill.BackgroundColor = XLColor.FromArgb(237, 204, 203);
                }

                cellRow++;
            }

            worksheet.Range($"B2:{--cellColumn}3").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Range($"B2:{cellColumn}3").Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            worksheet.Range($"B2:{cellColumn}{--cellRow}").Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

            foreach (var category in runners.Where(x => x.AgeCategory != null).Select(x => x.AgeCategory).Distinct())
            {
                if (category == null) continue;

                cellRow = 4;
                cellColumn = 'B';

                var sheet = workbook.AddWorksheet(category.Name);

                sheet.Cell("B2").Value = $"Výsledky {DateTime.Now.Date:d.M.yyyy} - {category.Name}";
                sheet.Cell("B2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                sheet.Cell($"{cellColumn++}3").Value = "Umístění";
                sheet.Cell($"{cellColumn++}3").Value = "Startovní číslo";
                sheet.Cell($"{cellColumn++}3").Value = "Jméno";
                sheet.Cell($"{cellColumn++}3").Value = "Příjmení";
                sheet.Cell($"{cellColumn++}3").Value = "Oddíl";
                sheet.Cell($"{cellColumn++}3").Value = "Datum narození";
                if (partners)
                {
                    sheet.Cell($"{cellColumn++}3").Value = "Jméno 2";
                    sheet.Cell($"{cellColumn++}3").Value = "Příjmení 2";
                    sheet.Cell($"{cellColumn++}3").Value = "Datum narození 2";
                }
                sheet.Cell($"{cellColumn++}3").Value = "Výsledný čas";
                sheet.Cell($"{cellColumn++}3").Value = "Celkový čas strávený čekáním";
                sheet.Cell($"{cellColumn++}3").Value = "Celkový trestný čas";
                sheet.Cell($"{cellColumn}3").Value = "Průměrný čas mezi stanovišti";

                sheet.Range($"B2:{cellColumn}2").Merge();

                var categoryRunners = runners.Where(x => x.AgeCategory != null && x.AgeCategory.ID == category.ID).ToList();

                place = 1;
                foreach (var runner in categoryRunners)
                {
                    cellColumn = 'B';

                    sheet.Cell($"{cellColumn++}{cellRow}").Value = place++;
                    sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.StartNumber;
                    sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.FirstName;
                    sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.LastName;
                    sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Team.ToString();
                    sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Birthdate;
                    if (partners)
                    {
                        sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Partner != null
                                                                            ? runner.Partner!.FirstName
                                                                            : string.Empty;
                        sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Partner != null
                                                                            ? runner.Partner!.LastName
                                                                            : string.Empty;
                        sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Partner != null
                                                                            ? runner.Partner!.Birthdate
                                                                            : string.Empty;
                    }
                    sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.FinalRunTime.HasValue
                                                                        ? @$"{runner.FinalRunTime.Value:hh\:mm\:ss}"
                                                                        : string.Empty;
                    sheet.Cell($"{cellColumn++}{cellRow}").Value = @$"{runner.TotalWaitTime:hh\:mm\:ss}";
                    sheet.Cell($"{cellColumn++}{cellRow}").Value = @$"{runner.TotalPenaltyTime:hh\:mm\:ss}";
                    sheet.Cell($"{cellColumn++}{cellRow}").Value = @$"{runner.AverageTimeBetweenCheckpoints:hh\:mm\:ss}";

                    if (runner.Disqualified)
                    {
                        var disqualificationCheckpoint = runner.CheckpointInfo.Find(x => x.Disqualified);
                        sheet.Cell($"{cellColumn}{cellRow}").Value = $"Diskvalifikován/a na stanovišti {disqualificationCheckpoint!.Checkpoint.Name}";
                        sheet.Range($"B{cellRow}:{(char)(cellColumn - 1)}{cellRow}").Style.Fill.BackgroundColor = XLColor.FromArgb(237, 204, 203);
                    }

                    cellRow++;
                }

                sheet.Range($"B2:{--cellColumn}3").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                sheet.Range($"B2:{cellColumn}3").Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                sheet.Range($"B2:{cellColumn}{--cellRow}").Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            }

            workbook.SaveAs(filePath);
        }

        public static List<Runner> LoadRunnersFromJSON(string filePath)
        {
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(fs, Encoding.GetEncoding("Windows-1250"));

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new CheckpointInfoJsonConverter(),
                    new RefereeJsonConverter(),
                    new DateTimeJsonConverter(),
                    new TimeSpanJsonConverter(),
                    new TeamJsonConverter()
                }
            };

            return JsonSerializer.Deserialize<List<Runner>>(reader.ReadToEnd(), options)!;
        }

        public static AllData LoadEverythingFromJSON(string filePath)
        {
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(fs, Encoding.GetEncoding("Windows-1250"));

            return JsonSerializer.Deserialize<AllData>(reader.ReadToEnd())!;
        }

        public static void ExportEverythingToJSON(AllData allData, string filePath)
        {
            using var fs = new FileStream(filePath, FileMode.Create);
            using var writer = new StreamWriter(fs, Encoding.GetEncoding("Windows-1250"));

            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                Converters = { new RunnerJsonConverter() }
            };

            writer.Write(JsonSerializer.Serialize(allData, options));
        }
    }

    public class CsvException : Exception
    {
        public CsvException(string message) : base(message) { }
    }
}
