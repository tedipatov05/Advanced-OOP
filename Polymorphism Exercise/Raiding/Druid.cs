using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int druidPower = 80;
        public Druid(string name) : base(name, druidPower)
        {

        }

        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {Name} healed for {Power}";
        }
    }
}
