using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turisticky_zavod.Data
{
    public class CheckpointRunnerInfo
    {
        public int ID { get; set; }
        public Checkpoint Checkpoint { get; set; }
        public Person Referee { get; set; }
        public DateTime TimeArrived { get; set; }
        public DateTime? TimeDeparted { get; set; }
        public TimeSpan TimeWaitedSeconds { get; set; }
        public TimeSpan PenaltySeconds { get; set; }
    }
}
