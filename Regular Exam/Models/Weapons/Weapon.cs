using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    using Contracts;
    using Utilities.Messages;
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }
        public double Price { get; private set; }

        public int DestructionLevel
        {
            get => this.destructionLevel;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                else if(value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                this.destructionLevel = value;
            }
        }
    }
}
