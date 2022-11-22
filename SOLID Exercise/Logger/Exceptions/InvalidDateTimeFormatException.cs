using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Exceptions
{
    public class InvalidDateTimeFormatException : Exception
    {
        private const string DefaultMessage = "Provided DateTime was not in the correct fromat!";

        public InvalidDateTimeFormatException()
            : base(DefaultMessage)
        {

        }


    }
}
