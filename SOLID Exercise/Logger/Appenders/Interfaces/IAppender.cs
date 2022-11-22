using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders.Interfaces
{
    using Messages.Interfaces;
    using Layout.Interfaces;
    using Enums;
    public interface IAppender
    {
        int Count { get; }

        ILayout Layout { get; }

        void Append(IMessage message);

        ReportLevel Level { get; }
    }
}
