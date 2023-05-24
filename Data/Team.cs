using System.ComponentModel;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data;

[JsonSerializable(typeof(Team))]
public class Team : INotifyPropertyChanged
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


    public event PropertyChangedEventHandler? PropertyChanged;

    public override string ToString() => Name ?? string.Empty;
}
