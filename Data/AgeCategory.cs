using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int AgeMax { get; set; }
        public bool Duo { get; set; } = false;
        public string? Color { get; set; }

        public static AgeCategory? GetByBirthYear(int birthYear)
        {
            if (birthYear == 0) return null;

            var age = DateTime.Now.Year - birthYear;
            return Database.Instance.AgeCategory.First(c => age >= c.AgeMin && age <= c.AgeMax);
        }

        public override string ToString() => Name;
    }
}
