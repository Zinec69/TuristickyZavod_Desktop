
namespace turisticky_zavod.Data
{
    public class BaseRunner : Person
    {
        public int ID { get; set; }

        public DateTime? Birthdate { get; set; }

        public Gender Gender { get; set; }
    }
}
