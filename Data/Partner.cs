using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(Partner))]
    public class Partner : BaseRunner { }
}
