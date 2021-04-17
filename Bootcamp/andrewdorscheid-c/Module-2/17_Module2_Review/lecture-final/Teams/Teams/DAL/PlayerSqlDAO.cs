using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Teams.Models;

namespace Teams.DAL
{
    public class PlayerSqlDAO : IPlayerDAO
    {
        private string connectionString;

        public PlayerSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /**
        Methods on the DAO:
            Get Player By Id
            Get Players on a team
            Find Players by name
        **/

        public Player GetPlayerById(int playerId)
        {
            Player player = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from Player Where PlayerId = @playerId", conn);
                // Bind parameters
                cmd.Parameters.AddWithValue("@playerId", playerId);
                SqlDataReader rdr = cmd.ExecuteReader();

                // Loop and create objects
                if (rdr.Read())
                {
                    player = RowToObject(rdr);
                }
            }

            return player;
        }

        public List<Player> GetPlayersByTeam(int teamId)
        {
            List<Player> list = new List<Player>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from Player where TeamId = @teamId", conn);
                cmd.Parameters.AddWithValue("@teamId", teamId);
                SqlDataReader rdr = cmd.ExecuteReader();

                // Loop and create objects
                while (rdr.Read())
                {
                    list.Add(RowToObject(rdr));
                }
            }
            return list;
        }

        public List<Player> SearchPlayers(string searchString)
        {
            List<Player> list = new List<Player>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from Player where FirstName like @search OR LastName like @search", conn);
                cmd.Parameters.AddWithValue("@search", $"%{searchString}%");
                SqlDataReader rdr = cmd.ExecuteReader();

                // Loop and create objects
                while (rdr.Read())
                {
                    list.Add(RowToObject(rdr));
                }
            }
            return list;
        }


        private Player RowToObject(SqlDataReader rdr)
        {
            Player player = new Player();

            player.PlayerId = Convert.ToInt32(rdr["PlayerId"]);
            player.FirstName = Convert.ToString(rdr["FirstName"]);
            player.LastName = Convert.ToString(rdr["LastName"]);

            // TODO: NOTE Handling of this nullable field
            if (rdr["TeamId"] is DBNull)
            {
                player.TeamId = null;
            }
            else
            {
                player.TeamId = Convert.ToInt32(rdr["TeamId"]);
            }
            player.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);
            player.Position = Convert.ToString(rdr["Position"]);
            return player;
        }
    }
}
