using System.Text;

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
        public string Color { get; set; }

        public static AgeCategory? GetByBirthYear(int birthYear, bool hasPartner)
        {
            if (birthYear <= 0) return null;

            var age = DateTime.Now.Year - birthYear;
            return Database.Instance.AgeCategory.Local.FirstOrDefault(c =>
                age >= c.AgeMin
                && (!c.AgeMax.HasValue || age <= c.AgeMax.Value)
                && c.Duo == hasPartner, null);
        }

        public static bool TryGetByString(string value, bool hasPartner, out AgeCategory? category)
        {
            category = null;

            if (string.IsNullOrEmpty(value)) return false;

            var categories = Database.Instance.AgeCategory;
            value = Encoding.UTF8.GetString(Encoding.GetEncoding("ISO-8859-8").GetBytes(value.ToLower()));

            if (hasPartner)
            {
                if ((value.Contains("30") && value.Contains("70")) || value == "k16")
                {
                    category = categories.First(x => x.ID == 9);
                    return true;
                }
                if (value.Contains("30") || value == "k15")
                {
                    category = categories.First(x => x.ID == 8);
                    return true;
                }
                if (value.Contains("70") || value == "k17")
                {
                    category = categories.First(x => x.ID == 10);
                    return true;
                }
            }
            else
            {
                if (value.Contains("nejmladsi") || value == "k1" || value == "k2")
                {
                    category = categories.First(x => x.ID == 1);
                    return true;
                }
                if (value.Contains("mladsi z") || value == "k3" || value == "k4")
                {
                    category = categories.First(x => x.ID == 2);
                    return true;
                }
                if (value.Contains("starsi z") || value == "k5" || value == "k6")
                {
                    category = categories.First(x => x.ID == 3);
                    return true;
                }
                if (value.Contains("mladsi d") || value == "k7" || value == "k8")
                {
                    category = categories.First(x => x.ID == 4);
                    return true;
                }
                if (value.Contains("starsi d") || value == "k9" || value == "k10")
                {
                    category = categories.First(x => x.ID == 5);
                    return true;
                }
                if ((value.Contains("muzi") || value.Contains("zeny") || value.Contains("dospeli")) && value.Contains('a')
                    || value == "k11" || value == "k12")
                {
                    category = categories.First(x => x.ID == 6);
                    return true;
                }
                if ((value.Contains("muzi") || value.Contains("zeny") || value.Contains("dospeli")) && value.Contains('b')
                    || value == "k13" || value == "k14")
                {
                    category = categories.First(x => x.ID == 7);
                    return true;
                }
            }

            return false;
        }

        public override string ToString() => Name;
    }
}
