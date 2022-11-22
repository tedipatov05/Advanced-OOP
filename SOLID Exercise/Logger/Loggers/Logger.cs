using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers
{
    using Appenders.Interfaces;
    using Appenders;
    using Enums;
    using Interfaces;
    using Common;
    using Messages.Interfaces;
    using Messages;
    using Layout;

    public class Logger : IAppenderCollection, ILogger
    {
        private readonly ICollection<IAppender> appenders;

        private Logger()
        {
            appenders = new List<IAppender>();
        }

        public Logger(params IAppender[] appenders)
        {
           this.appenders.AddRange(appenders);
        }
        public IReadOnlyCollection<IAppender> Appenders => this.appenders.AsReadOnly();
        public void AddAppender(IAppender appender)
        {

            this.appenders.Add(appender);
        }

        public void Clear()
        {
            appenders.Clear();
        }

        public void Critical(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Critical);
        }

        public void Error(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Error);
        }

        public void Fatal(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Fatal);
        }

        public void Info(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Info);
        }

        public void RemoveAppender(IAppender appender)
        {
            this.appenders.Remove(appender);
           
        }

        public void Warning(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Warning);
        }
        public void SaveLogs(string filename)
        {
            int counter = 1;
            foreach(IAppender appender in this.Appenders)
            {
                if(appender is IFileAppender fileAppender)
                {
                    if (fileAppender.Layout.GetType() == typeof(XmlLayout))
                    {
                        fileAppender.SaveLogFile($"log_{counter++}.xml");
                    }
                    else
                    {
                        fileAppender.SaveLogFile($"log_{counter++}.txt");
                    }
                }
            }
        }
        private void LogMessage(string logtime, string messageText, ReportLevel reportLevel)
        {
            IMessage message = new Message(logtime, messageText, reportLevel);  
            foreach(IAppender appender in this.Appenders)
            {
                if (appender.Level <= reportLevel)
                {
                    appender.Append(message);
                }
            }
        }
    }
}
