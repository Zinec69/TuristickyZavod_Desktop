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
        [JsonIgnore]
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
        public string PartnerBirthYear { get { return (Partner != null && Partner.BirthYear.HasValue) ? Partner.BirthYear.Value.ToString() : "-"; } }
    }
}
