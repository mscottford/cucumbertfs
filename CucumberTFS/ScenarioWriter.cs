using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CucumberTfs
{
    public class ScenarioWriter
    {
        private Scenario[] scenarios;
        private TextWriter writer;

        public ScenarioWriter(Scenario[] scenarios)
        {
            this.scenarios = scenarios;

            var stream = new FileStream("tfs.feature", FileMode.Create);
            this.writer = new StreamWriter(stream, Encoding.ASCII);
        }

        public void Write()
        {
            WriteHeader();
            WriteEmptyLine();

            foreach (Scenario scenario in scenarios)
            {
                Write(scenario);
                WriteEmptyLine();
            }

            Save();
        }

        private void WriteHeader()
        {
            writer.WriteLine("Feature: TFS Scenarios");
            writer.WriteLine("In order to write an awesome application");
            writer.WriteLine("As a TFS user");
            writer.WriteLine("I want to run scenarios stored in TFS");
        }

        private void Write(Scenario scenario)
        {
            writer.Write("Scenario: ");
            writer.WriteLine("{0} - {1}", scenario.Id, scenario.Title);

            foreach (string line in scenario.Description.Lines())
            {
                writer.WriteLine(line);
            }
        }

        private void WriteEmptyLine()
        {
            writer.WriteLine();
        }

        private void Save()
        {
            writer.Flush();
            writer.Close();
        }
    }

    static class StringExtension 
    {
        public static string[] Lines(this string input) 
        {
            return input.Split('\n');
        }
    }
}
