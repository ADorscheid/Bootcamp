using System.Collections.Generic;
using Teams.Models;

namespace Teams.DAL
{
    public interface IPlayerDAO
    {
        Player GetPlayerById(int playerId);
        List<Player> GetPlayersByTeam(int teamId);
        List<Player> SearchPlayers(string searchString);
    }
}