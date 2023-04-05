using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(CheckpointRunnerInfo))]
    public class CheckpointRunnerInfo
    {
        public int ID { get; set; }

        [JsonPropertyName("checkpointId")]
        public virtual Checkpoint Checkpoint { get; set; }

        public DateTime TimeArrived { get; set; }
        public DateTime? TimeDeparted { get; set; }

        [JsonPropertyName("timeWaitedSeconds")]
        public TimeSpan TimeWaited { get; set; }

        [JsonPropertyName("penaltySeconds")]
        public TimeSpan Penalty { get; set; }

        [JsonPropertyName("refereeName")]
        public Referee RefereeJsonDeserializing { set => Checkpoint.Referee =  value; }
    }
}
