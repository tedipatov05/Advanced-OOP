using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core
{
    using Interfaces;
    using Logger.Appenders.Interfaces;
    using Logger.Loggers.Interfaces;
    using Loggers;

    internal class Engine : IEngine
    {
        private ILogger logger;

        public Engine()
        {
            logger = new Logger();
        }
        public void Start()
        {
           /* ICollection<IAppender> appenders = new List<IAppender>();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] appendersArgs = Console.ReadLine()
                    .Split();

                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];

                IAppender appender;
                if(appendersArgs.Length == 2)
                {
                    appender = this.
                }
            }
           */
        }
    }
}
