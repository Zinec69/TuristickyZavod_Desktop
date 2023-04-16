using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(Runner))]
    public class Runner : BaseRunner
    {
        public int? StartNumber { get; set; }

        public int TeamID { get; set; }

        [ForeignKey(nameof(TeamID))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Team Team { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? FinishTime { get; set; }

        public bool Disqualified { get; set; }


        public int? PartnerID { get; set; }

        [ForeignKey(nameof(PartnerID))]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        [JsonIgnore]
        public virtual Partner? Partner { get; set; }

        public List<CheckpointRunnerInfo> CheckpointInfo { get; set; } = new();

        public int? AgeCategoryID { get; set; }

        [ForeignKey(nameof(AgeCategoryID))]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        [JsonIgnore]
        public virtual AgeCategory? AgeCategory { get; set; }


        [NotMapped]
        [JsonIgnore]
        public string PartnerFirstName { get { return Partner != null ? Partner.FirstName : "-"; }  }


        [NotMapped]
        [JsonIgnore]
        public string PartnerLastName { get { return Partner != null ? Partner.LastName : "-"; } }


        [NotMapped]
        [JsonIgnore]
        public DateTime? PartnerBirthdate { get => Partner?.Birthdate; }

        [NotMapped]
        [JsonIgnore]
        public TimeSpan? FinalRunTime
        {
            get
            {
                if (!StartTime.HasValue || !FinishTime.HasValue)
                    return null;
                else
                {
                    var finalTime = FinishTime.Value - StartTime.Value;

                    foreach (var c in CheckpointInfo)
                    {
                        finalTime += c.Penalty;
                        finalTime -= c.TimeWaited;
                    }

                    return finalTime;
                }
            }
        }

        [NotMapped]
        [JsonIgnore]
        public TimeSpan TotalWaitTime
        {
            get
            {
                var totalWaitTime = new TimeSpan();

                foreach (var c in CheckpointInfo)
                    totalWaitTime += c.TimeWaited;

                return totalWaitTime;
            }
        }

        [NotMapped]
        [JsonIgnore]
        public TimeSpan TotalPenaltyTime
        {
            get
            {
                var totalPenaltyTime = new TimeSpan();

                foreach (var c in CheckpointInfo)
                    totalPenaltyTime += c.Penalty;

                return totalPenaltyTime;
            }
        }

        [NotMapped]
        [JsonIgnore]
        public TimeSpan AverageTimeBetweenCheckpoints
        {
            get
            {
                var time = new TimeSpan();

                var checkpoints = CheckpointInfo.SkipWhile(x => x.ID == 1);
                if (checkpoints.Any())
                {
                    foreach (var c in checkpoints)
                    {
                        time += c.TimeDeparted!.Value - c.TimeArrived;
                    }
                    
                    if (time.TotalSeconds > 0)
                        time /= checkpoints.Count();
                }

                return time;
            }
        }

        [NotMapped]
        [JsonIgnore]
        public int? Placement
        {
            get 
            {
                var runners = Database.Instance.Runner.Local.Where(x => x.FinalRunTime != null)
                                                            .OrderBy(x => x.FinalRunTime).ToList();
                var placement = runners.FindIndex(x => x.ID == this.ID);

                return placement > -1 ? placement + 1 : null;
            }
        }
    }
}
