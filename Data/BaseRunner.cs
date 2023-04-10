
namespace turisticky_zavod.Data
{
    public class BaseRunner : Person
    {
        public int ID { get; set; }

        private int? birthYear;
        public int? BirthYear
        {
            get => birthYear;
            set
            {
                if (value.HasValue && value.Value < 1000)
                {
                    var currentYear = DateTime.Now.Year;

                    value += value.Value > (currentYear - 2000) ? 1900 : 2000;
                }
                birthYear = value;
            }
        }
    }
}
