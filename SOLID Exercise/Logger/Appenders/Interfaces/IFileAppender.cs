using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders.Interfaces
{
    using IO.Interfaces;
    internal interface IFileAppender : IAppender
    {
        ILogFile LogFile { get; }

        void SaveLogFile(string filename);
    }
}
