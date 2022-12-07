using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class SandwichMenu
    {
        Dictionary<string, SandwichPrototype> sandwiches = new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get { return sandwiches[name]; }
            set { sandwiches.Add(name, value); } 
        }

    }
}
