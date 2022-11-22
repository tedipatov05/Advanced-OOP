using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Atributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}
