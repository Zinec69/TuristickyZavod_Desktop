using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(Runner), TypeInfoPropertyName = "Runners")]
    public class Runner : BaseRunner
    {
        //[Display(AutoGenerateField = true, Name = "Startovní číslo", Order = 1)]
        public int? StartNumber { get; set; }

        public int TeamID { get; set; }

        //[Display(AutoGenerateField = true, Name = "Oddíl", Order = 5)]
        [ForeignKey(nameof(TeamID))]
        public virtual Team Team { get; set; }

        //[Display(AutoGenerateField = false)]
        public DateTime? StartTime { get; set; }

        //[Display(AutoGenerateField = false)]
        public DateTime? FinishTime { get; set; }

        //[Display(AutoGenerateField = true, Name = "Diskvalifikován/a", Order = 10)]
        public bool Disqualified { get; set; }


        //[Display(AutoGenerateField = false)]
        public int? PartnerID { get; set; }

        //[Display(AutoGenerateField = false)]
        [ForeignKey(nameof(PartnerID))]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Partner? Partner { get; set; }


        //[Display(AutoGenerateField = false)]
        public List<CheckpointRunnerInfo> CheckpointInfo { get; set; } = new();

        public int? AgeCategoryID { get; set; }

        //[Display(AutoGenerateField = true, Name = "Věková kategorie", Order = 6)]
        [ForeignKey(nameof(AgeCategoryID))]
        public virtual AgeCategory? AgeCategory { get; set; }


        //[Display(AutoGenerateField = true, Name = "Jméno 2", Order = 8)]
        [NotMapped]
        public string PartnerFirstName { get { return Partner != null ? Partner.FirstName : "-"; }  }


        //[Display(AutoGenerateField = true, Name = "Příjmení 2", Order = 9)]
        [NotMapped]
        public string PartnerLastName { get { return Partner != null ? Partner.LastName : "-"; } }


        //[Display(AutoGenerateField = true, Name = "Ročník 2", Order = 7)]
        [NotMapped]
        public string PartnerBirthYear { get { return (Partner != null && Partner.BirthYear.HasValue) ? Partner.BirthYear.Value.ToString() : "-"; } }
    }
}
