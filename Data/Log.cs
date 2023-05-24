using System.ComponentModel;

namespace turisticky_zavod.Data;

public class Log : INotifyPropertyChanged
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

    private string message;
    public string Message
    {
        get => message;
        set
        {
            message = value;
            Timestamp = DateTime.Now;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
        }
    }

    private string type;
    public string Type
    {
        get => type;
        set
        {
            type = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
        }
    }

    private DateTime timestamp;
    public DateTime Timestamp
    {
        get => timestamp;
        private set
        {
            timestamp = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Timestamp)));
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    public override string ToString()
        => $"{timestamp:HH:mm:ss} [{type.ToUpper()}] {message}";
}
