using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.IO
{
    using Interfaces;
    using System.IO;

    public class FileWriter : IFileWriter
    {
        public string FilePath { get; set; }

        public FileWriter(string filePath)
        {
            FilePath = filePath;
        }

        public void WriteContent(string content, string fileName)
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(this.FilePath);
            }
            string outputPath = Path.Combine(FilePath, fileName);
            
            File.WriteAllText(outputPath, content, Encoding.UTF8);
        }
    }
}
