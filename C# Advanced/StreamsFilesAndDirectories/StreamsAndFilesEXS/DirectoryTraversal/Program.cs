using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory);
            var files = directory.GetFiles();

            var filesByExtension = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                var extension = file.Extension;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension[extension] = new Dictionary<string, long>();
                }

                filesByExtension[extension][file.Name] = file.Length;
            }
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var writer = new StreamWriter($"{desktopPath}" + "/report.txt"))
            {
                foreach (var extension in filesByExtension
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value))
                {
                    writer.WriteLine(extension.Key);
                    
                    foreach (var file in extension.Value
                        .OrderBy(x => x.Value)
                        .ToDictionary(x => x.Key, x => x.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value / 1000.0:F3}kb");
                    }
                }
            }
        }
    }
}
