using MenuFramework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TeamsClient.Models;

namespace TeamsClient
{
    public class MainMenu : ConsoleMenu
    {
        string baseApiUrl;
        RestClient client;
        public MainMenu(string baseApiUrl)
        {
            this.baseApiUrl = baseApiUrl;
            // Create a rest client
            this.client = new RestClient(baseApiUrl);
            AddOption("List Teams", ListTeams);
            AddOption("Exit", Exit);
        }

        private MenuOptionResult ListTeams()
        {
            // Create a Rest Request to the /teams url.  Get back a list of Team.
            RestRequest request = new RestRequest("teams");
            IRestResponse<List<Team>> response = client.Get<List<Team>>(request);

            // TODO: Error checking


            List<Team> teams = response.Data;

            // Display the teams to the user
            foreach(Team team in teams)
            {
                Console.WriteLine($"{team.TeamName}");
            }


            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
