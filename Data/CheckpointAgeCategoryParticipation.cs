using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace turisticky_zavod.Data
{
    [PrimaryKey(nameof(CheckpointID), new string[] { nameof(AgeCategoryID) })]
    public class CheckpointAgeCategoryParticipation
    {
        public int CheckpointID { get; set; }

        [ForeignKey(nameof(CheckpointID))]
        public virtual Checkpoint Checkpoint { get; set; }

        public int AgeCategoryID { get; set; }

        [ForeignKey(nameof(AgeCategoryID))]
        public virtual AgeCategory AgeCategory { get; set; }

        public bool IsParticipating { get; set; }


        [NotMapped]
        public string CheckpointName { get => Checkpoint.Name; }
    }
}
