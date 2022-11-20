using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
