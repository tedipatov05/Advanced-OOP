using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Atributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            if(value is int num)
            {
                return num > minValue && num < maxValue;
            }
            return false;
        }
    }
}
