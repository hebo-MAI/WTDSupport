using System;
using System.Diagnostics;
using System.IO;

namespace WTDSupport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Execute(args);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.ReadKey();
            }
        }

        private static void Execute(string[] args)
        {
            string content;
            string mmlOutFileName = string.Empty;
            string wtdOutFileName = string.Empty;
            string wscOutFileName = string.Empty;
            string wsrOutFileName = string.Empty;

            Console.Write("Writing MML: ");
            {
                content = File.ReadAllText(args[0]);
                var directory = Path.GetDirectoryName(args[0]);
                var filename_wo_ext = Path.GetFileNameWithoutExtension(args[0]);
                var reader = new MMLReader(content);
                var baseFileName = Path.Combine(directory, filename_wo_ext);
                mmlOutFileName = baseFileName + ".MML";
                wtdOutFileName = baseFileName + ".WTD";
                wscOutFileName = baseFileName + ".WSC";
                wsrOutFileName = baseFileName + ".WSR";
                Console.WriteLine(mmlOutFileName);
                Console.WriteLine(wtdOutFileName);
                Console.WriteLine(wscOutFileName);
                Console.WriteLine(wsrOutFileName);
                File.WriteAllText(mmlOutFileName, reader.GetMMLString());

                Console.WriteLine("Success");
            }

            var settingsPath = File.ReadAllText(settingsFileName);

            Console.Write("Making WTD: ");
            {
                Process p = new Process();
                p.StartInfo.FileName = Path.Combine(settingsPath, wtcFileName);
                p.StartInfo.Arguments = mmlOutFileName;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                p.WaitForExit();
                Console.WriteLine("Success");
                Console.WriteLine(p.StandardOutput.ReadToEnd());
                p.Close();
            }

            Console.Write("Making WSC: ");
            {
                Process p = new Process();
                p.StartInfo.FileName = Path.Combine(settingsPath, wsmakeFileName);
                p.StartInfo.WorkingDirectory = settingsPath;
                p.StartInfo.Arguments = wtdOutFileName;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                p.WaitForExit();
                Console.WriteLine("Success");
                Console.WriteLine(p.StandardOutput.ReadToEnd());
                p.Close();
            }

            Console.WriteLine("Rename to .wsr");
            File.Delete(wsrOutFileName);
            File.Move(wscOutFileName, wsrOutFileName);

            Console.WriteLine("Delete the object file");
            File.Delete(wtdOutFileName);
        }

        private const string settingsFileName = "settings.txt";
        private const string wtcFileName = "WTC.exe";
        private const string wsmakeFileName = "WSMAKE.exe";
    }
}
