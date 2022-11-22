using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Models
{
    using Utilities.Atributes;
    public class Person
    {
        private const int AgeMin = 12;
        private const int AgeMax = 90;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }
        [MyRange(AgeMin, AgeMax)]
        public int Age { get; set; }
    }
}
