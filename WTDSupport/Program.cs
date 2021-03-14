using System;
using System.IO;

namespace WTDSupport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string content;
            try
            {
                content = File.ReadAllText(args[0]);
                var directory = Path.GetDirectoryName(args[0]);
                var filename_wo_ext = Path.GetFileNameWithoutExtension(args[0]);
                File.WriteAllText(Path.Combine(directory, filename_wo_ext) + ".MML", content);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
