using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace TestClaEvaluate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing ClaEvaluate output");
            string arg = "'test'";
            Console.WriteLine("arg={0}, result={1}", arg, DoEvaluate(arg));
            arg = "Format(Today(), @D06)";
            Console.WriteLine("arg={0}, result={1}", arg, DoEvaluate(arg));

            Console.ReadKey();
        }

        private static object DoEvaluate(string arg)
        {
            Process p = new Process();
            p.StartInfo.FileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ClaEvaluate.exe");
            p.StartInfo.Arguments = "\"" + arg + "\"";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            string rv = p.StandardOutput.ReadToEnd();

            p.WaitForExit();
            return rv;
        }
    }
}
