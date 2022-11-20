using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double IncrementIncreaseWeight = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void FeedIt(Food food)
        {
            int quantity = food.Quantity;
            base.Weight += quantity * IncrementIncreaseWeight;
            base.FoodEaten += quantity;
        }
    }
}
