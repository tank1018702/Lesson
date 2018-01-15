using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DosCmd
{
    class Program
    {
        private static string InvokeCmd(string cmdArgs)
        {
            string Tstr = "";
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            p.StandardInput.WriteLine("echo off");
            p.StandardInput.WriteLine(""+cmdArgs);
            p.StandardInput.WriteLine("exit");

            Tstr = p.StandardOutput.ReadToEnd();
            p.Close();
            return Tstr;
        }

        static void Main(string[] args)
        {
            string s = InvokeCmd("dir");
            Console.WriteLine(s);

            Console.ReadKey();
        }
    }
}
