using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    using Models.Contracts;
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }
        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Health 
        { 
            get => this.health;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if(value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weapon = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void AddWeapon(IWeapon weapon)
            => this.Weapon = weapon;


        public void TakeDamage(int points)
        {
            var armourLeft = this.Armour - points;
            if (armourLeft >= 0)
            {
                this.Armour = armourLeft;
            }
            else
            {
               
                this.Armour = 0;

                var healthLeft = Health + armourLeft;

                if (healthLeft < 0)
                {
                    Health = 0;
                }
                else
                {
                    this.Health = healthLeft;
                }
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name}: {Name}");
            result.AppendLine($"--Health: {this.Health}");
            result.AppendLine($"--Armour: {Armour}");
            result.Append($"--Weapon: {(Weapon == null ? "Unarmed" : Weapon.Name)}");

            return result.ToString();
        }
    }
}
