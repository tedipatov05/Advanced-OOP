using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.IO
{
    using IO.Interfaces;
    public class LogFile : ILogFile
    {
        private readonly StringBuilder sbContent;
        private readonly IFileWriter fileWriter;

        public LogFile(IFileWriter fileWriter)
            :this()
        {
            this.fileWriter = fileWriter;
        }

        private LogFile()
        {
            sbContent = new StringBuilder();
        }
        public int Size => sbContent.Length;

        public string Content => sbContent.ToString();

        public void SaveAs(string filename)
        {
            this.fileWriter.WriteContent(Content, filename);
        }

        public void Write(string content)
        {
            this.sbContent.AppendLine(content);
        }
    }
}
