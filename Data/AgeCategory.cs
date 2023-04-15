using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [JsonSerializable(typeof(AgeCategory))]
    public class AgeCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public CategoryType Type { get; set; } = CategoryType.DEFAULT;
        public string Color { get; set; }
        public Gender Gender { get; set; }

        public static bool TryGetByBirthdate(DateTime birthdate, ICollection<AgeCategory> allCategories, Gender gender, out AgeCategory? category,
                CategoryType type = CategoryType.DEFAULT, DateTime? partnerBirthdate = null)
        {
            category = new();

            var today = DateTime.Today;

            var age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age))
                age--;

            if (type == CategoryType.DUOS && partnerBirthdate.HasValue)
            {
                var partnerAge = today.Year - partnerBirthdate.Value.Year;
                if (partnerBirthdate.Value.Date > today.AddYears(-partnerAge))
                    partnerAge--;
                age += partnerAge;
            }

            category = allCategories.FirstOrDefault(x =>
                age >= x.AgeMin
                && (!x.AgeMax.HasValue || age <= x.AgeMax.Value)
                && (type == CategoryType.DUOS || x.Gender == gender)
                && x.Type == type, null);

            return category != null;
        }

        public override string ToString() => Name ?? "-";

        [NotMapped]
        [JsonIgnore]
        public string TypeString
        {
            get => Type switch
            {
                CategoryType.DEFAULT => "Klasický",
                CategoryType.DUOS    => "Dvojice",
                CategoryType.RELAY   => "Štafety",
                _ => "-"
            };
        }
    }

    public enum CategoryType { DEFAULT, DUOS, RELAY }
}
