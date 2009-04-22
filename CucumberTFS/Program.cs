using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CucumberTfs
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = new Arguments(args);
            var repository = new ScenarioRepository(arguments.First);

            var writer = new ScenarioWriter(repository.GetScenarios());
            writer.Write();
        }
    }
}
