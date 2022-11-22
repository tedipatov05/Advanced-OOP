using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using CommandPattern.Common;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdSplit = args.Split(' ');
            string cmdName = cmdSplit[0];
            string[] cmdArgs = cmdSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type cmdType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == $"{cmdName}Command" /*&& t.GetInterfaces().Any(i => i == typeof(ICommand))*/);
            if(cmdType == null)
            {
                throw new InvalidOperationException(string.Format(ErrorMessages.InvalidCommandType, $"{cmdType}Command"));
            }

            object cmdInstance = Activator.CreateInstance(cmdType);

            MethodInfo executeMethod = cmdType
                .GetMethods()
                .First();
           string result = (string)executeMethod.Invoke(cmdInstance, new object[] {cmdArgs});
            return result;
        }
    }
}
