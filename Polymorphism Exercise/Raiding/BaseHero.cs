using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public string Name { get; protected set; }
        public int Power { get; protected set; }

        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public abstract string CastAbility();
    }
}
