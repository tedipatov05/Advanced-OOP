using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthable
    {
        public string Name { get; private set; }    
        public string BirthDate { get; private set; }

        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
