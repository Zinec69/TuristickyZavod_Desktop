using System.Text.Json.Serialization;

namespace Data
{
    [JsonSerializable(typeof(Runner), TypeInfoPropertyName = "Runners")]
    public class Runner : Person
    {
        public int? RunnerID { get; set; }
        public int BirthYear { get; set; }
        public string Team { get; set; }
        public long StartTime { get; set; }
        public long? FinishTime { get; set; }
        public bool Disqualified { get; set; }

        public virtual List<CheckpointRunnerInfo> CheckpointInfo { get; set; } = new();
        public Runner? Partner { get; set; }
        public AgeCategory? AgeCategory { get => AgeCategory.GetByBirthYear(BirthYear); }

        public string StartTimeFormatted
        {
            get => StartTime != default
                ? DateTimeOffset.FromUnixTimeMilliseconds(StartTime).TimeOfDay.ToString("hh':'mm':'ss")
                : "-";
        }
        public string FinishTimeFormatted
        {
            get => FinishTime.HasValue && FinishTime != default
                ? DateTimeOffset.FromUnixTimeMilliseconds(FinishTime.Value).TimeOfDay.ToString("hh':'mm':'ss")
                : "-";
        }
        public string AgeCategoryFormatted { get => AgeCategory != null ? AgeCategory.Name : "-"; }
    }
}
