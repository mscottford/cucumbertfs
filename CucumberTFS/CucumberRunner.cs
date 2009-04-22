using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;

namespace CucumberTfs
{
    public class CucumberRunner
    {
        public void Run(params string[] args)
        {
            var cucumberBatch = GetFullPath("cucumber");

            var process = new Process();
            process.StartInfo = new ProcessStartInfo("ruby", cucumberBatch + " " + String.Join(" ", args));

            process.Start();
            process.WaitForExit();

            Environment.ExitCode = process.ExitCode;
        }

        private string GetFullPath(string file)
        {
            string path = Environment.GetEnvironmentVariable("PATH");

            var roots = path.Split(';');
            string fullFileName = null;
            foreach (string root in roots)
            {
                fullFileName = Path.Combine(root, file);
                if (File.Exists(fullFileName))
                {
                    break;
                }
            }

            if (!File.Exists(fullFileName))
            {
                throw new Exception("Cucumber not found");
            }

            return fullFileName;
        }
    }
}
