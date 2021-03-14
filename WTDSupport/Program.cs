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
                File.WriteAllText(args[0] + ".MML", content);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
