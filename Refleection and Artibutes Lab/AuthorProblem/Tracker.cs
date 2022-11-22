using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methodInfos = type.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);
            foreach(MethodInfo methodInfo in methodInfos)
            {
                if(methodInfo.CustomAttributes.Any(m => m.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = methodInfo.GetCustomAttributes(false);
                    foreach(AuthorAttribute authorAttribute in attributes)
                    {
                        Console.WriteLine($"{methodInfo.Name} is written by {authorAttribute.Name}");
                    }
                }
            }

        }
    }
}
