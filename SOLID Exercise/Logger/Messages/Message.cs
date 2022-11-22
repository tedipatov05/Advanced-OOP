using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Messages
{
    using Interfaces;
    using Logger.Enums;
    using Exceptions;
    using Validators.Interfaces;
    using Validators;

    internal class Message : IMessage
    {
        private string logtime;
        private string messageText;

        private const string EmptyOrNullMessage = "Argument cannot be an empty string";
        public Message()
        {
            validator = new DateTimeValidator();
        }
        public Message(string logTime, string messageText, ReportLevel level)
            :this()
        {
            LogTime = logTime;
            MessageText = messageText;
            Level = level;
        }
        private IValidator validator;
        public string LogTime
        {
            get { return logtime; }
            private set
            {
                if (!validator.IsValid(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(LogTime), EmptyOrNullMessage);
                }
                logtime = value;
            }
        }


        public string MessageText
        {
            get { return messageText; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(MessageText), EmptyOrNullMessage);
                }
                messageText = value;
            }
        }
        

        public ReportLevel Level { get; }

       
        

        
    }
}
