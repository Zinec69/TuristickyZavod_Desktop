using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data;

[JsonSerializable(typeof(CheckpointRunnerInfo))]
public class CheckpointRunnerInfo : INotifyPropertyChanged
{
    private int id;
    public int ID
    {
        get => id;
        set
        {
            id = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
        }
    }

    private int checkpointID;
    public int CheckpointID
    {
        get => checkpointID;
        set
        {
            checkpointID = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckpointID)));
        }
    }

    private Checkpoint checkpoint;
    [ForeignKey(nameof(CheckpointID))]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public virtual Checkpoint Checkpoint
    {
        get => checkpoint;
        set
        {
            checkpoint = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Checkpoint)));
            checkpoint.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(checkpoint.Referee))
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckpointRefereeName)));
                }
            };
        }
    }

    private DateTime? timeArrived;
    public DateTime? TimeArrived
    {
        get => timeArrived;
        set
        {
            timeArrived = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeArrived)));
        }
    }

    private DateTime? timeDeparted;
    public DateTime? TimeDeparted
    {
        get => timeDeparted;
        set
        {
            timeDeparted = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeDeparted)));
        }
    }

    private TimeSpan timeWaited;
    public TimeSpan TimeWaited
    {
        get => timeWaited;
        set
        {
            timeWaited = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeWaited)));
        }
    }

    private TimeSpan penalty;
    public TimeSpan Penalty
    {
        get => penalty;
        set
        {
            penalty = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Penalty)));
        }
    }

    private bool disqualified;
    public bool Disqualified
    {
        get => disqualified;
        set
        {
            disqualified = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Disqualified)));
        }
    }

    public string CheckpointRefereeName => Checkpoint.Referee?.Name ?? "-";


    public event PropertyChangedEventHandler? PropertyChanged;
}
