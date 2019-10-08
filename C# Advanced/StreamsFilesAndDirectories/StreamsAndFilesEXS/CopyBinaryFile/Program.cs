using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream(@"..\..\..\copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream(@"..\..\..\copyResult.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    var readBytes = 0;

                    while ((readBytes = reader.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
