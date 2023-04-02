
namespace turisticky_zavod.Data
{
    public class Team
    {
        public int ID {  get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
