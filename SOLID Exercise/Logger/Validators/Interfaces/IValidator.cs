using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Validators.Interfaces
{
    internal interface IValidator
    {
        bool IsValid(object value);
    }
}
