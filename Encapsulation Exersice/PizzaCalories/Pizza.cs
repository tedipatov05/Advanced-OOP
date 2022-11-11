using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(name) || name.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);

            if (toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        public double GetCalories()
        {
            double calories = 0;

            foreach (var top in toppings)
            {
                calories += top.GetCalories();
            }

            return dough.GetCalories() + calories;
        }

        public override string ToString()
        {
            return $"{Name} - {GetCalories():F2} Calories.";
        }
    }
}
