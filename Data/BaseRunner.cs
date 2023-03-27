using System.ComponentModel.DataAnnotations;

namespace turisticky_zavod.Data
{
    public class BaseRunner : Person
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Display(AutoGenerateField = true, Name = "Ročník", Order = 4)]
        public int? BirthYear { get; set; }
    }
}
