using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(Checkpoint))]
    public class Checkpoint
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int? RefereeID { get; set; }

        [JsonPropertyName("refereeName")]
        [ForeignKey(nameof(RefereeID))]
        [DeleteBehavior(DeleteBehavior.SetNull)]
        [JsonIgnore]
        public virtual Referee? Referee { get; set; }
    }
}
