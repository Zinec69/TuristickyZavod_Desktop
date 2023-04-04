using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(Team))]
    public class Team
    {
        public int ID {  get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
