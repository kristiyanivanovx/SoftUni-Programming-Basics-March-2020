using DI.Interfaces;

namespace DI.Models
{
    public class Copy
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Copy(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void CopyAllText()
        {
            string text = reader.Read();
            writer.Write(text);
        }
    }
}
