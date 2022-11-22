using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    using Interfaces;
    using Logger.IO.Interfaces;
    using Logger.Layout.Interfaces;
    using Logger.Messages.Interfaces;
    using Formaters;
    using Logger.Enums;

    internal class FileAppender : IAppender, IFileAppender
    {
        private readonly IFormater formater;

        private FileAppender()
        {
            this.Count = 0;
        }
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel level)
            : this()
        {
            this.Layout = layout;
            this.LogFile = logFile;
            this.Level = level;
        }
        public ILogFile LogFile { get; }

        public int Count { get; }

        public ILayout Layout { get; }

        public ReportLevel Level { get; }

        public void Append(IMessage message)
        {
            string formatedMessage = formater.FormatMessage(message);
            LogFile.Write(formatedMessage);
        }

        public void SaveLogFile(string filename)
        {
            LogFile.SaveAs(filename);
        }
    }
}
