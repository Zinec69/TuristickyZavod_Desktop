using System.ComponentModel.DataAnnotations;

namespace turisticky_zavod.Data
{
    public class BaseRunner : Person
    {
        [Key]
        public int ID { get; set; }
        public int? BirthYear { get; set; }
    }
}
