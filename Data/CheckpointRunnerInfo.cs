using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CheckpointRunnerInfo
    {
        public int ID { get; set; }
        public Checkpoint Checkpoint { get; set; }
        public Person Referee { get; set; }
        public long TimeArrived { get; set; }
        public long? TimeDeparted { get; set; }
        public int TimeWaitedSeconds { get; set; }
        public int PenaltySeconds { get; set; }
    }
}
