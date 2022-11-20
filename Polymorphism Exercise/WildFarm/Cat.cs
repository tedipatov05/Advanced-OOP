using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WildFarm
{
    public class Cat : Feline
    {
        private const double IncrementIncreaseWeight = 0.30;
        private ICollection<Type> foodTypes = new List<Type> { typeof(Vegetable), typeof(Meat) };

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void FeedIt(Food food)
        {
            if (!foodTypes.Any(f => f.Name == food.GetType().Name))
            {
                string exceptionMessages = String.Format(ExceptionMessages.InvalidFoodException, this.GetType().Name, food.GetType().Name);
                throw new ArgumentException(exceptionMessages);
            }

            int quantity = food.Quantity;
            base.Weight += quantity * IncrementIncreaseWeight;
            base.FoodEaten += quantity;
        }
    }
}
