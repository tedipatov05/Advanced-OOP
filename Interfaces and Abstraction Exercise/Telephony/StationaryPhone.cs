using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            
            return $"Dialing... {number}";

            
        }
        /*private bool ValidateNumber(string number)
        {
            foreach(char ch in number)
            {
                if (!Char.IsDigit(ch))
                {
                    return false;
                }

            }

            return true;
        }
        */
    }
}
