using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    public class Referee : Person
    {
        public int ID { get; set; }
    }

    public class CheckpointRunnerInfo
    {
        public int ID { get; set; }

        [JsonPropertyName("checkpointId")]
        public virtual Checkpoint Checkpoint { get; set; }

        [JsonPropertyName("refereeName")]
        public virtual Referee Referee { get; set; }
        public DateTime TimeArrived { get; set; }
        public DateTime? TimeDeparted { get; set; }
        public TimeSpan TimeWaitedSeconds { get; set; }
        public TimeSpan PenaltySeconds { get; set; }
    }
}
