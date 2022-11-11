using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;
        private double modifier = 2;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;

            switch (type.ToLower())
            {
                case "meat": modifier *= 1.2; break;
                case "veggies": modifier *= 0.8; break;
                case "cheese": modifier *= 1.1; break;
                case "sauce": modifier *= 0.9; break;
            }
        }

        public string Type
        {
            get => type;

            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }

        public double Weight
        {
            get => weight;

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        public double GetCalories()
        {
            return weight * modifier;
        }
    }
}
