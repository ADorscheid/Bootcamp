using System.Collections.Generic;
using Teams.Models;

namespace Teams.DAL
{
    public interface ITeamDAO
    {
        List<Team> GetAllTeams();
        Team GetTeamById(int teamId);
    }
}