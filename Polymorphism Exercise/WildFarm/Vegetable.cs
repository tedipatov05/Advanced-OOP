using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Vegetable : Food
    {
        public override int Quantity { get; set; }

        public Vegetable(int quantity) : base(quantity)
        {
            
        }
    }
}
