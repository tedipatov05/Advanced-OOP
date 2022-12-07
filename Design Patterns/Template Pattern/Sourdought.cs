using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Pattern
{
    public class Sourdought : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Shourdough Bread");
        }
    }
}
