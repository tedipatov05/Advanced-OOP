using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public  class Cake : Dessert
    {
        private const double grams = 250;
        private const double calories = 1000;
        private const decimal CakePrice = 5;

        public override double Calories  => calories;

        public override decimal Price => CakePrice;

        public override double Grams => grams;

        public Cake(string name)
            :base(name, 0, 0, 0)
        {

        }
    }
}
