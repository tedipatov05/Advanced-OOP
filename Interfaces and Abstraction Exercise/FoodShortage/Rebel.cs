﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {

        public string Name { get;  set; }

        public int Age { get; private set; }
        public string Group { get; private set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;

        }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food+=5;
        }
    }
}
