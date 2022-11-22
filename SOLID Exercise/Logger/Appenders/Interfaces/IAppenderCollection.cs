using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders.Interfaces
{
    public interface IAppenderCollection
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void AddAppender(IAppender appender);

        void RemoveAppender(IAppender appender);

        void Clear();
    }

}
