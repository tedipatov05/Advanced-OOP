using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Formaters
{
    using Messages.Interfaces;
    using Layout.Interfaces;
    internal interface IFormater
    {
        ILayout layout { get; }
        string FormatMessage(IMessage message);

    }
}
