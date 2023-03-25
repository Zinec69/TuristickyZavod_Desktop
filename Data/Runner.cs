using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    public class BaseRunner : Person
    {
        [Key]
        public int ID { get; set; } = -1;
        public int? BirthYear { get; set; }
    }

    public class Partner : BaseRunner { }

    [JsonSerializable(typeof(Runner), TypeInfoPropertyName = "Runners")]
    public class Runner : BaseRunner
    {
        public int? RunnerID { get; set; }
        public string Team { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public bool Disqualified { get; set; }

        public int? PartnerID { get; set; }

        [ForeignKey(nameof(PartnerID))]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Partner? Partner { get; set; }

        public List<CheckpointRunnerInfo> CheckpointInfo { get; set; } = new();

        public AgeCategory? AgeCategory { get { return BirthYear.HasValue ? AgeCategory.GetByBirthYear(BirthYear.Value) : null; } }


        [NotMapped]
        public string PartnerFirstName { get { return Partner != null ? Partner.FirstName : "-"; }  }

        [NotMapped]
        public string PartnerLastName { get { return Partner != null ? Partner.LastName : "-"; } }

        [NotMapped]
        public int? PartnerBirthYear { get { return (Partner != null && Partner.BirthYear.HasValue) ? Partner.BirthYear.Value : null; } }
    }
}
