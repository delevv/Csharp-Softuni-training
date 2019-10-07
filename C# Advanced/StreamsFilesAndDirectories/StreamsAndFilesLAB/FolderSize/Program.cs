using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"..\..\..\TestFolder");
            var sum = 0.0;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }
            sum = sum / 1024 / 1024;

            File.WriteAllText(@"..\..\..\output.txt", sum.ToString());
        }
    }
}
