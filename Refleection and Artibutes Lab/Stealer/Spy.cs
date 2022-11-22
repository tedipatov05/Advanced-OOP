using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] namesOfFields)
        {
            Type classType = Type.GetType(nameOfClass);
            FieldInfo[] filedsInfo = classType.GetFields(BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Static
                | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            var classInstance = Activator.CreateInstance(classType, new object[] {});
            sb.AppendLine($"Class under investigation: {nameOfClass}");

            foreach(FieldInfo field in filedsInfo)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fieldsInfo = classType.GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.Static);
            MethodInfo[] publicMethods = classType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public);
            MethodInfo[] nonPublicMethods = classType.GetMethods(
               BindingFlags.Instance |
               BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach(FieldInfo field in fieldsInfo)
            {
                sb.AppendLine($"{field.Name} must be private");
            }

            foreach(MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private");
            }

            foreach(MethodInfo methodInfo in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo} have to be public");
            }

            return sb.ToString().Trim();

        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methodInfos = classType.GetMethods(
                BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach(MemberInfo methodInfo in methodInfos)
            {
                sb.AppendLine($"{methodInfo.Name}");
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] methodInfos = classType.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public 
                | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            foreach(MethodInfo methodInfo in methodInfos.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
            }

            foreach(MethodInfo method in methodInfos.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }

}
