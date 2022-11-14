using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdenticable, IBirthable
    {
        private string name;
        private int age; 


        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;  
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string BirthDate { get; private set; }
    }
}
