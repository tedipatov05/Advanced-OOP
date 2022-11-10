using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double coffeeMilliliters = 30;
        private const decimal coffeePrice = 3.5M;

        public Coffee(string name, double caffeine)
            :base(name, 0, 0)
        {
            Caffeine = caffeine;
        }

        public override double Milliliters => coffeeMilliliters;
        public override decimal Price => coffeePrice;

        public double Caffeine { get; set; }
    }
}
