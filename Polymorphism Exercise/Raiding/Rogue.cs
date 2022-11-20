﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int roguePower = 80;

        public Rogue(string name) : base(name, roguePower)
        {

        }
        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {Name} hit for {Power} damage";
        }
    }
}
