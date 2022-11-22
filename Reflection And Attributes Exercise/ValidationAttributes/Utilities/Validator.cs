using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using ValidationAttributes.Utilities.Atributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties()
                .Where(prop => prop.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute))).ToArray();
            foreach(PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);


                foreach(CustomAttributeData customAttributeData in property.CustomAttributes)
                {
                    Type customAttrType = customAttributeData.AttributeType;
                    object attrInstance = property.GetCustomAttribute(customAttrType);

                    MethodInfo method = customAttrType.GetMethods()
                        .First(m => m.Name == "IsValid");
                    bool result =(bool)method.Invoke(attrInstance, new object[] { value });
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
