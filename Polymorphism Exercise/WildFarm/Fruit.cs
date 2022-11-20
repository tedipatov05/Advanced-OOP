using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Fruit : Food
    {
        public override int Quantity { get; set; }
        public Fruit(int quantity) : base(quantity)
        {
           
        }
    }
}
