using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal : IAnimal
    {
        private double weight;
        private string name;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                name = value;
            }
        }

        public double Weight
        {
            get => weight;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                weight = value;
            }
        }

        public int FoodEaten { get; protected set; }

        public abstract void FeedIt(Food food);

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
