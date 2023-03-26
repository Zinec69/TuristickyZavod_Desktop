namespace turisticky_zavod.Data
{
    public class AgeCategory
    {
        public int ID { get; set; }
        private string? name;
        public string Name { get { return name ?? "-"; } set { name = value; } }
        private string? code;
        public string Code { get { return code ?? "-"; } set { code = value; } }
        public int AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public bool Duo { get; set; } = false;
        public string? Color { get; set; }

        public static AgeCategory? GetByBirthYear(int birthYear, bool hasPartner)
        {
            if (birthYear <= 0) return null;

            var age = DateTime.Now.Year - birthYear;
            return Database.Instance.AgeCategory.ToList().FirstOrDefault(c => (c.AgeMax.HasValue ? age >= c.AgeMin && age <= c.AgeMax : age >= c.AgeMin) && c.Duo == hasPartner, null);
        }

        public override string ToString() => Name;
    }
}
