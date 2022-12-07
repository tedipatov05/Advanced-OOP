using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }
        
        public override SandwichPrototype Clone()
        {
            string ingreadientList = GetIngredients();
            Console.WriteLine($"Cloning sandich with ingredients {ingreadientList}");

            return MemberwiseClone() as SandwichPrototype;
        }
        public string GetIngredients()
        {
            return $"{bread} {meat} {cheese} {veggies}";
        }
    }
}
