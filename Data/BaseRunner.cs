using System.ComponentModel;

namespace turisticky_zavod.Data;

public abstract class BaseRunner : Person, INotifyPropertyChanged
{
    private DateTime? birthdate;
    public DateTime? Birthdate
    {
        get => birthdate;
        set
        {
            birthdate = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Birthdate)));
        }
    }

    private Gender gender;
    public Gender Gender
    {
        get => gender;
        set
        {
            gender = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gender)));
        }
    }


    public new event PropertyChangedEventHandler? PropertyChanged;
}
