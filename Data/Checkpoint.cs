using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    public class Checkpoint
    {
        public int CheckpointID { get; set; }
        public string Name { get; set; }

        public int? RefereeID { get; set; }

        [JsonPropertyName("refereeName")]
        [ForeignKey(nameof(RefereeID))]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual Referee? Referee { get; set; }
    }
}
