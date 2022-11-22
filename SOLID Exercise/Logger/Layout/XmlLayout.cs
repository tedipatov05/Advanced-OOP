﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layout
{
    using Interfaces;
    public class XmlLayout : ILayout
    {
        public string Format =>
            "<log>" + Environment.NewLine
            + "<date>{0}</date>" + Environment.NewLine
            + "<level>{1}</level>" + Environment.NewLine
            + "<message>{2}</message>" + Environment.NewLine
            + "</log>";

    }
}
