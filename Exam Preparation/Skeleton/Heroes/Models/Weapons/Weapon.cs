using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    using Models.Contracts;
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
    


        protected Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
            
        }
        public string Name 
        { 
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Weapon type cannot be null or empty.");
                }
                this.name = value;
            }
        }


        public int Durability
        {
            get { return durability; }
            protected set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                this.durability = value;
            }
        }


        public abstract int DoDamage();
        
       
    }
}
