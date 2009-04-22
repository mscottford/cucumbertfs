using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace CucumberTfs
{
    public class ScenarioRepository
    {
        private string serverName;

        public ScenarioRepository(string serverName)
        {
            this.serverName = serverName;
        }

        public Scenario[] GetScenarios()
        {
            var result = new List<Scenario>();

            result.AddRange(GetActiveScenarios());
            result.AddRange(GetClosedScenarios());

            return result.ToArray();
        }

        public Scenario[] GetActiveScenarios()
        {
            var query = "select System.ID, System.Title, System.Description from WorkItems where System.WorkItemType = 'Scenario' and System.State = 'Active' order by System.Id";
            return GetScenariosForQuery(query);
        }

        public Scenario[] GetClosedScenarios()
        {
            var query = "select System.ID, System.Title, System.Description from WorkItems where System.WorkItemType = 'Scenario' and System.State = 'Closed' and System.Reason = 'Completed' order by System.Id";
            return GetScenariosForQuery(query);
        }

        private Scenario[] GetScenariosForQuery(string query)
        {
            var server = TeamFoundationServerFactory.GetServer(serverName);
            var store = (WorkItemStore)server.GetService(typeof(WorkItemStore));

            var workItems = store.Query(query);

            var result = new List<Scenario>();
            foreach (WorkItem workItem in workItems)
            {
                var scenario = new Scenario(workItem.Id, workItem.Title, workItem.Description);
                result.Add(scenario);
            }

            return result.ToArray();
        }
    }
}
