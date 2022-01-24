using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int bufferSize = 1024;
            using (FileStream fileStreamOutput = new FileStream("copied.png", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                FileStream fileStreamInput = new FileStream("copyMe.png", FileMode.Open, FileAccess.ReadWrite);
                fileStreamOutput.SetLength(fileStreamInput.Length);

                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];

                while ((bytesRead = fileStreamInput.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStreamOutput.Write(bytes, 0, bytesRead);
                }
            }
        }
    }
}
