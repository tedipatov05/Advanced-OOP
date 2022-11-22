using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Validators
{
    using Validators.Interfaces;
    internal class DateTimeValidator : IValidator
    {
        public bool IsValid(object text)
           => DateTime.TryParse((string)text, out DateTime date);
    }
}
