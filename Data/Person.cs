using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data;

[NotMapped]
public abstract class Person : INotifyPropertyChanged
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


    private string firstName;

    [JsonIgnore]
    public string FirstName
    {
        get => firstName;
        set
        {
            firstName = value.Trim();
            if (!string.IsNullOrEmpty(lastName))
            {
                name = $"{FirstName} {LastName}";
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
        }
    }


    private string lastName;

    [JsonIgnore]
    public string LastName
    {
        get => lastName;
        set
        {
            lastName = value.Trim();
            if (!string.IsNullOrEmpty(firstName))
            {
                name = $"{FirstName} {LastName}";
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
        }
    }


    private string name;

    [NotMapped]
    public string Name
    {
        get => string.IsNullOrEmpty(name)
                ? (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                    ? string.Empty
                    : $"{FirstName} {LastName}"
                : name;
        set
        {
            name = value.Trim();
            var lastSpaceIndex = name.LastIndexOf(' ');
            FirstName = lastSpaceIndex >= 0 ? name[..lastSpaceIndex] : name;
            LastName = lastSpaceIndex >= 0 ? name[(lastSpaceIndex + 1)..] : name;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
}
