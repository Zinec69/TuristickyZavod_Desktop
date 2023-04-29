using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(CheckpointRunnerInfo))]
    public class CheckpointRunnerInfo
    {
        public int ID { get; set; }

        public int CheckpointID { get; set; }

        [ForeignKey(nameof(CheckpointID))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Checkpoint Checkpoint { get; set; }

        public DateTime? TimeArrived { get; set; }
        public DateTime? TimeDeparted { get; set; }
        public TimeSpan TimeWaited { get; set; }
        public TimeSpan Penalty { get; set; }

        public bool Disqualified { get; set; }

        public string CheckpointRefereeName { get => Checkpoint.Referee?.Name ?? "-"; }
    }
}
