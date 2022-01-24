using System;
using System.IO;
using System.Linq;
using SOLID.Models.Enumeration;
using SOLID.Models.Interfaces;

namespace SOLID.Files
{
    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;

        public LogFile(IPathManager pathManager)
        {
            this.pathManager = pathManager;
            this.pathManager.EnsureDirectoryAndFileExists();
        }

        public string Path => this.pathManager.CurrentFilePath;

        public long Size => this.CalculateFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format, dateTime.ToString("G"), level.ToString(), message);
            return formattedMessage;
        }

        private long CalculateFileSize()
        {
            return File.ReadAllText(this.Path)
                       .ToCharArray()
                       .Where(c => char.IsLetter(c))
                       .Sum(c => c);
        }
    }
}
