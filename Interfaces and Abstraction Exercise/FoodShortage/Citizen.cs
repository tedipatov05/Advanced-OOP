using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        public int Food { get; private set; } = 0;   

        public string Name { get;  set; }    
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string BirthDate { get; private set; }

        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
