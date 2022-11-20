using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Meat : Food
    {
        public override int Quantity { get; set; }
        public Meat(int quantity) : base(quantity)
        {

        }
    }
}
