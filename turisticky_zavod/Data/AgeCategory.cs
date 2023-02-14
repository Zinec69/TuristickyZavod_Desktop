using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turisticky_zavod.Data
{
    public class AgeCategory
    {
        public string Name { get; }
        public string Code { get; }

        public AgeCategory(int birth_year, bool duos)
        {
            var age = DateTime.Now.Year - birth_year;
            if (duos)
            {
                if (age <= 10)
                {
                    Name = "Nejmladší žáci a žákyně";
                }
                else if (age <= 12)
                {
                    Name = "Mladší žáci a žákyně";
                }
                else if (age <= 14)
                {
                    Name = "Starší žáci a žákyně";
                }
                else if (age <= 16)
                {
                    Name = "Mladší dorostenci a dorostenky";
                }
                else if (age <= 18)
                {
                    Name = "Starší dorostenci a dorostenky";
                }
                else if (age <= 35)
                {
                    Name = "Dospělí A";
                }
                else
                {
                    Name = "Dospělí B";
                }
            }
            else
            {
                if (age <= 30)
                {
                    Name = "Do 30 let";
                }
                else if (age <= 70)
                {
                    Name = "31-70 let";
                }
                else
                {
                    Name = "Nad 70 let";
                }
            }
        }
        public AgeCategory(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
