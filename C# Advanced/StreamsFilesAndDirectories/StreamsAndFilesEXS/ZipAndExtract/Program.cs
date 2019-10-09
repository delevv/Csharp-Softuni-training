using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            var zipPath = $"../../../resultZip.zip";
            var filesToZip = $"../../../copyMe.png";

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(filesToZip, "copyMe.png");
            }

            ZipFile.ExtractToDirectory(zipPath, desktopPath);

        }
    }
}
