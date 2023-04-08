using ClosedXML.Excel;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    public static class FileHelper
    {
        public static List<Runner> LoadFromCSV(string filePath)
        {
            List<Runner> runners = new();
            var database = Database.Instance;

            using var reader = new StreamReader(filePath, Encoding.GetEncoding("Windows-1250"));

            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()?.Split(';');
                if (line != null && line.Length >= 5)
                {
                    int? birthYear = int.TryParse(line[3].Trim(), out int result) ? result : null;
                    if (birthYear.HasValue && birthYear.Value < 1000)
                    {
                        var currentYear = DateTime.Now.Year;
                        var currentYearLastTwoNumbers = int.Parse(currentYear.ToString()[^2..]);
                        if (birthYear.Value > currentYearLastTwoNumbers)
                            birthYear += 1900;
                        else
                            birthYear += 2000;
                    }

                    var runner = new Runner()
                    {
                        StartNumber = !string.IsNullOrEmpty(line[0].Trim()) ? int.Parse(line[0].Trim()) : null,
                        LastName = line[1].Trim(),
                        FirstName = line[2].Trim(),
                        BirthYear = birthYear,
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
                    database.Runner.Add(runner);
                }
            }

            return runners;
        }

        public static void ExportToExcel(List<Runner> runners, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Celkové výsledky");
                worksheet.Cell("B2").Value = $"Výsledky {DateTime.Now.Date:d.M.yyyy}";
                worksheet.Cell("B2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                var partners = runners.Any(x => x.Partner != null);

                var cellRow = 4;
                var cellColumn = 'B';

                worksheet.Cell($"{cellColumn++}3").Value = "Pořadí";
                worksheet.Cell($"{cellColumn++}3").Value = "Startovní číslo";
                worksheet.Cell($"{cellColumn++}3").Value = "Jméno";
                worksheet.Cell($"{cellColumn++}3").Value = "Příjmení";
                worksheet.Cell($"{cellColumn++}3").Value = "Oddíl";
                worksheet.Cell($"{cellColumn++}3").Value = "Ročník";
                worksheet.Cell($"{cellColumn++}3").Value = "Věková kategorie";
                if (partners)
                {
                    worksheet.Cell($"{cellColumn++}3").Value = "Jméno 2";
                    worksheet.Cell($"{cellColumn++}3").Value = "Příjmení 2";
                    worksheet.Cell($"{cellColumn++}3").Value = "Ročník 2";
                }
                worksheet.Cell($"{cellColumn++}3").Value = "Výsledný čas";
                worksheet.Cell($"{cellColumn++}3").Value = "Celkový čas strávený čekáním";
                worksheet.Cell($"{cellColumn++}3").Value = "Celkový trestný čas";
                worksheet.Cell($"{cellColumn}3").Value = "Průměrný čas mezi stanovišti";

                worksheet.Range($"B2:{cellColumn}2").Merge();

                runners = runners.Where(x => !x.Disqualified && x.FinalRunTime.HasValue).OrderBy(x => x.FinalRunTime.Value).ToList()
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
                    worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.BirthYear;
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
                                                                            ? runner.Partner!.BirthYear
                                                                            : string.Empty;
                    }
                    worksheet.Cell($"{cellColumn++}{cellRow}").Value = runner.FinalRunTime.HasValue
                                                                        ? @$"{runner.FinalRunTime.Value:hh\:mm\:ss}"
                                                                        : string.Empty;
                    worksheet.Cell($"{cellColumn++}{cellRow}").Value = @$"{runner.TotalWaitTime:hh\:mm\:ss}";
                    worksheet.Cell($"{cellColumn++}{cellRow}").Value = @$"{runner.TotalPenaltyTime:hh\:mm\:ss}";
                    worksheet.Cell($"{cellColumn++}{cellRow}").Value = @$"{runner.AverageTimeBetweenCheckpoints:hh\:mm\:ss}";

                    if (runner.Disqualified)
                    {
                        worksheet.Cell($"{cellColumn}{cellRow}").Value = "Diskvalifikován/a";
                        worksheet.Range($"B{cellRow}:{(char)(cellColumn - 1)}{cellRow}").Style.Fill.BackgroundColor = XLColor.FromArgb(230, 184, 183);
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

                    sheet.Cell($"{cellColumn++}3").Value = "Pořadí";
                    sheet.Cell($"{cellColumn++}3").Value = "Startovní číslo";
                    sheet.Cell($"{cellColumn++}3").Value = "Jméno";
                    sheet.Cell($"{cellColumn++}3").Value = "Příjmení";
                    sheet.Cell($"{cellColumn++}3").Value = "Oddíl";
                    sheet.Cell($"{cellColumn++}3").Value = "Ročník";
                    if (partners)
                    {
                        sheet.Cell($"{cellColumn++}3").Value = "Jméno 2";
                        sheet.Cell($"{cellColumn++}3").Value = "Příjmení 2";
                        sheet.Cell($"{cellColumn++}3").Value = "Ročník 2";
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
                        sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.BirthYear;
                        if (partners)
                        {
                            sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Partner != null
                                                                                ? runner.Partner!.FirstName
                                                                                : string.Empty;
                            sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Partner != null
                                                                                ? runner.Partner!.LastName
                                                                                : string.Empty;
                            sheet.Cell($"{cellColumn++}{cellRow}").Value = runner.Partner != null
                                                                                ? runner.Partner!.BirthYear
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
                            sheet.Cell($"{cellColumn}{cellRow}").Value = "Diskvalifikován/a";
                            sheet.Range($"B{cellRow}:{(char)(cellColumn - 1)}{cellRow}").Style.Fill.BackgroundColor = XLColor.FromArgb(230, 184, 183);
                        }

                        cellRow++;
                    }

                    sheet.Range($"B2:{--cellColumn}3").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    sheet.Range($"B2:{cellColumn}3").Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    sheet.Range($"B2:{cellColumn}{--cellRow}").Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                }

                workbook.SaveAs(filePath);
            }
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
                    new RefereeJsonConverter(),
                    new CheckpointJsonConverter(),
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

    internal class RefereeJsonConverter : JsonConverter<Referee>
    {
        public override Referee Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var name = reader.GetString();
            var referee = Database.Instance.Referee.ToList().FirstOrDefault(x => x.Name == name, null);
            referee ??= Database.Instance.ChangeTracker.Entries<Referee>()
                                                       .FirstOrDefault(x => x.Entity.Name == name, null)?.Entity
                                                        ?? new() { Name = reader.GetString() };

            return referee;
        }

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
            var team = Database.Instance.Team.ToList().FirstOrDefault(x => x.Name == name, null);
            team ??= Database.Instance.ChangeTracker.Entries<Team>()
                                                    .FirstOrDefault(x => x.Entity.Name == name, null)?.Entity
                                                     ?? new() { Name = name };

            return team;
        }

        public override void Write(Utf8JsonWriter writer, Team value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Name);
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
                writer.WriteNumber("CheckpointID", item.Checkpoint.ID);
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
