using System;
using System.IO;

namespace SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {

            var parts = 4;
            var totalSize = new FileInfo(@"..\..\..\sliceMe.txt").Length;
            var partSize = (int)totalSize / parts;

            using (var read = new FileStream(@"..\..\..\sliceMe.txt", FileMode.Open))
            {
                for (int i = 1; i <= parts; i++)
                {
                    if (i == parts)
                    {
                        partSize = (int)(totalSize - (partSize * (parts - 1)));
                    }
                    var buffer = new byte[partSize];                   

                    read.Read(buffer, 0,partSize);

                    using (var writer = new FileStream($@"..\..\..\Part-{i}.txt", FileMode.OpenOrCreate))
                    {
                        writer.Write(buffer, 0,partSize);
                    }
                }
            }
        }
    }
}
