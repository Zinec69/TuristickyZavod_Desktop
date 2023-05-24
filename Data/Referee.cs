using System.ComponentModel;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data;

[JsonSerializable(typeof(Referee))]
public class Referee : Person, INotifyPropertyChanged
{

}
