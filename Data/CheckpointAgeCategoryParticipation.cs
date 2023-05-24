using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data;

[JsonSerializable(typeof(CheckpointAgeCategoryParticipation))]
[PrimaryKey(nameof(CheckpointID), new string[] { nameof(AgeCategoryID) })]
public class CheckpointAgeCategoryParticipation : INotifyPropertyChanged
{
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
    [JsonIgnore]
    public virtual Checkpoint Checkpoint
    {
        get => checkpoint;
        set
        {
            checkpoint = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Checkpoint)));
        }
    }

    private int ageCategoryID;
    public int AgeCategoryID
    {
        get => ageCategoryID;
        set
        {
            ageCategoryID = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AgeCategoryID)));
        }
    }

    private AgeCategory ageCategory;
    [ForeignKey(nameof(AgeCategoryID))]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    [JsonIgnore]
    public virtual AgeCategory AgeCategory
    {
        get => ageCategory;
        set
        {
            ageCategory = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AgeCategory)));
        }
    }

    private bool isParticipating;
    public bool IsParticipating
    {
        get => isParticipating;
        set
        {
            isParticipating = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsParticipating)));
        }
    }

    [NotMapped]
    [JsonIgnore]
    public bool CheckpointDisqualifiable
    {
        get => Checkpoint.Disqualifiable;
        set => Checkpoint.Disqualifiable = value;
    }


    public event PropertyChangedEventHandler? PropertyChanged;
}
