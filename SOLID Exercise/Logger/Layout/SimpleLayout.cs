using System;
using System.Collections.Generic;
using System.Text;


namespace Logger.Layout
{
    using Interfaces;
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";

    }
}
