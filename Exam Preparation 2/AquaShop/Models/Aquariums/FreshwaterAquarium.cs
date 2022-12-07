using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    using Decorations.Contracts;
    using Fish.Contracts;
    public class FreshwaterAquarium : Aquarium
    {
        private const int Capacity = 50;
        public FreshwaterAquarium(string name) : base(name, Capacity)
        {
          
        }
    }
}
