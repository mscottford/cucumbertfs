using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CucumberTfs.Tests
{
    [TestClass]
    public class ScenarioRepositoryTests
    {
        [TestMethod]
        public void GetActiveScenarios()
        {
            var serverName = "10.159.152.72";
            var repository = new ScenarioRepository(serverName);

            var scenarios = repository.GetActiveScenarios();

            foreach (var scenario in scenarios)
            {
                Console.Out.WriteLine("{0}, {1}, {2}", scenario.Id, scenario.Title, scenario.Description);
            }
        }
    }
}
