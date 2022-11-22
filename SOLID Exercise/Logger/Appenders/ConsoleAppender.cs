using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    using Interfaces;
    using Logger.Layout.Interfaces;
    using Logger.Messages.Interfaces;
    using Formaters;
    using Logger.Enums;

    public class ConsoleAppender : IAppender
    {
        private readonly IFormater formater;

        public ConsoleAppender()
        {
            Count = 0;
        }
        public ConsoleAppender(ILayout layout, ReportLevel level)
            :this()
        {
            Layout = layout;
            formater = new MessageFormater(Layout);
            this.Level = level;

        }
        public int Count { get; private set; }

        public ILayout Layout { get; }

        public ReportLevel Level { get; }

        public void Append(IMessage message)
        {
            string formatMessage = formater.FormatMessage(message);

            Console.WriteLine(formatMessage);
            this.Count++;
        }

        
        
    }
}
