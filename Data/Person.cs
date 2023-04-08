using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace turisticky_zavod.Data
{
    [NotMapped]
    public class Person
    {
        private string firstName;

        [JsonIgnore]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                if (!string.IsNullOrEmpty(lastName))
                {
                    name = $"{FirstName} {LastName}";
                }
            }
        }

        private string lastName;

        [JsonIgnore]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                if (!string.IsNullOrEmpty(firstName))
                {
                    name = $"{FirstName} {LastName}";
                }
            }
        }

        private string name;

        [NotMapped]
        public string Name
        {
            get
            {
                return string.IsNullOrEmpty(name) ? $"{FirstName} {LastName}" : name;
            }
            set
            {
                name = value;
                var lastSpaceIndex = name.LastIndexOf(' ');
                FirstName = lastSpaceIndex >= 0 ? name[..lastSpaceIndex] : name;
                LastName = lastSpaceIndex >= 0 ? name[(lastSpaceIndex + 1)..] : name;
            }
        }
    }
}
