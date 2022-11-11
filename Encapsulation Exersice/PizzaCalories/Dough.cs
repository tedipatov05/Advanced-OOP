using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string type;
        private string bakingTechnique;
        private double weight;
        private double modifier = 2;

        public Dough(string type, string bakingTechnique, double weight)
        {
            Type = type;
            BakingTechnique = bakingTechnique;
            Weight = weight;

            switch (type.ToLower())
            {
                case "white": modifier *= 1.5; break;
                case "wholegrain": modifier *= 1.0; break;
            }

            switch (bakingTechnique.ToLower())
            {
                case "crispy": modifier *= 0.9; break;
                case "chewy": modifier *= 1.1; break;
                case "homemade": modifier *= 1.0; break;
            }
        }

        public string Type
        {
            get => type;

            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                type = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;

            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => weight;

            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
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
