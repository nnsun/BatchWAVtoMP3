using System;
using System.Diagnostics;
using System.IO;

namespace BatchWAVtoMP3
{
    class Program
    {
        public const string fileExtension = ".mp3";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your directory's path: ");
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                int dotIndex = file.LastIndexOf('.');
                string newFile = file.Substring(0, dotIndex);
                newFile += fileExtension;
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "lame.exe";
                process.StartInfo.Arguments = string.Format("-b 128 \"{0}\" \"{1}\"", file, newFile);
                process.Start();
                process.WaitForExit();
            }
        }
    }
}
