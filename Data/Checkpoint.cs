using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data;

[JsonSerializable(typeof(Checkpoint))]
public class Checkpoint : INotifyPropertyChanged
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

    private string name;
    public string Name
    {
        get => name;
        set
        {
            name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        }
    }

    private bool disqualifiable = false;
    public bool Disqualifiable
    {
        get => disqualifiable;
        set
        {
            disqualifiable = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Disqualifiable)));
        }
    }

    private int? refereeID;
    public int? RefereeID
    {
        get => refereeID;
        set
        {
            refereeID = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RefereeID)));
        }
    }

    private Referee? referee;
    [JsonIgnore]
    [ForeignKey(nameof(RefereeID))]
    [DeleteBehavior(DeleteBehavior.SetNull)]
    public virtual Referee? Referee
    {
        get => referee;
        set
        {
            referee = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Referee)));
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    public override string ToString() => name;
}
