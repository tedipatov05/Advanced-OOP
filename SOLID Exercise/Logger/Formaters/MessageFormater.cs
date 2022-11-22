using Logger.Layout.Interfaces;
using Logger.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Formaters
{
    internal class MessageFormater : IFormater
    {
        public ILayout layout { get; }

        public MessageFormater(ILayout layout)
        {
            this.layout = layout;
        }

        public string FormatMessage(IMessage message)
        => string.Format(layout.Format, message.LogTime, message.Level.ToString(), message.MessageText);
    }
}
