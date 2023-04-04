using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(CheckpointAgeCategoryParticipation))]
    [PrimaryKey(nameof(CheckpointID), new string[] { nameof(AgeCategoryID) })]
    public class CheckpointAgeCategoryParticipation
    {
        public int CheckpointID { get; set; }

        [ForeignKey(nameof(CheckpointID))]
        [JsonIgnore]
        public virtual Checkpoint Checkpoint { get; set; }

        public int AgeCategoryID { get; set; }

        [ForeignKey(nameof(AgeCategoryID))]
        [JsonIgnore]
        public virtual AgeCategory AgeCategory { get; set; }

        public bool IsParticipating { get; set; }


        [NotMapped]
        [JsonIgnore]
        public string CheckpointName { get => Checkpoint.Name; }
    }
}
