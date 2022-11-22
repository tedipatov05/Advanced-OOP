using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Messages.Interfaces
{
    using Enums;
    public interface IMessage
    {
        string LogTime { get; }
        string MessageText { get; }

        ReportLevel Level { get; }
    }
}
