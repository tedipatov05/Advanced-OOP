using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{

    using Models.Decorations.Contracts;
    public abstract class Decoration : IDecoration
    {
        public int Comfort { get;}

        public decimal Price {get; }

        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }
    }
}
