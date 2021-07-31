using SOLID.Models.Enumeration;
using SOLID.Models.Interfaces;

using SOLID.IOManagement;
using SOLID.IOManagement.Interfaces;

namespace SOLID.Models.Appenders
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;

        public FileAppender(ILayout layout, Level level, IFile file)
            : base(layout, level)
        {
            this.File = file;
            this.writer = new FileWriter(this.File.Path);
        }

        public IFile File { get; }

        public override void Append(IError error)
        {
            string formatted = this.File.Write(this.Layout, error);
            this.writer.Write(formatted);
            this.messagesAppended += 1;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}";
        }
    }
}
