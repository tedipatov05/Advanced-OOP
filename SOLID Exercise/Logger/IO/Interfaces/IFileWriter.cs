using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.IO.Interfaces
{
    public interface IFileWriter
    {
        string FilePath { get; set; }

        void WriteContent(string content, string fileName);
    }
}
