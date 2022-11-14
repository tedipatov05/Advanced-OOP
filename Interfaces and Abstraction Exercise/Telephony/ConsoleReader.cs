using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}
