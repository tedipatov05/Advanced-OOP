using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd;

        public RandomList()
        {
            rnd = new Random();
        }
       
        public string RemoveRandomElement()
        {
            int index = rnd.Next(0, this.Count);
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }
    }
}
