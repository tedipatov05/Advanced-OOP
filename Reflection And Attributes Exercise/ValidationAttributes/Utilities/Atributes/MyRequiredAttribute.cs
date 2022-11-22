using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Atributes
{
    [AttributeUsage(AttributeTargets.Field| AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is string str)
            {
                return !string.IsNullOrEmpty(str);
            }

            return value != null;

        }
    }
}
