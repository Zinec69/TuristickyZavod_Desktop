﻿using System.ComponentModel.DataAnnotations.Schema;
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
                var split_name = value.Split(' ');
                FirstName = split_name[0];
                LastName = split_name[1];
            }
        }
    }
}
