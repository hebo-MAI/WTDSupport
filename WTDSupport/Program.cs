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
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
