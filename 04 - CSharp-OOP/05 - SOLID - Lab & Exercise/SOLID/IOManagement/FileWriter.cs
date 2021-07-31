using System;
using System.IO;

using SOLID.IOManagement.Interfaces;

namespace SOLID.IOManagement
{
    class FileWriter : IWriter
    {
        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; }

        public void Write(string text)
        {
            File.WriteAllText(this.FilePath,text);
        }

        public void WriteLine(string text)
        {
            File.WriteAllText(this.FilePath, text + Environment.NewLine);
        }
    }
}
