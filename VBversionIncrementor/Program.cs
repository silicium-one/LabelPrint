using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VBversionIncrementor
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"..\..\..\git-last-tag.bat",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                }
            };
            process.Start();
            var verFromTag = process.StandardOutput.ReadToEnd();
            verFromTag = Regex.Replace(verFromTag, "\r\n", "");

            string text = File.ReadAllText(@"..\..\..\LabelPrint\My Project\AssemblyInfo.vb");
            text = Regex.Replace(text, @"\r\n<Assembly: AssemblyVersion\((.*?)\)", "\r\n<Assembly: AssemblyVersion(\"" + verFromTag + "\")");
            File.WriteAllText(@"..\..\..\LabelPrint\My Project\AssemblyInfo.vb", text);
        }
    }
}
