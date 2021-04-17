using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teams.Models;

namespace Teams.DAL
{
    public class TeamSqlDAO
    {
        private string connectionString;

        public TeamSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /**
        Methods on the DAO:
            GetAllTeams()
            GetTeamById(id)
        **/

        public List<Team> GetAllTeams()
        {
            List<Team> list = new List<Team>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from Team", conn);
                // No parameters bind
                SqlDataReader rdr = cmd.ExecuteReader();

                // Loop and create objects
                while (rdr.Read())
                {
                    list.Add(RowToObject(rdr));
                }
            }
            return list;
        }

        public Team GetTeamById(int teamId)
        {
            Team team = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from Team Where TeamId = @teamId", conn);
                // Bind parameters
                cmd.Parameters.AddWithValue("@teamId", teamId);
                SqlDataReader rdr = cmd.ExecuteReader();

                // Loop and create objects
                if (rdr.Read())
                {
                    team = RowToObject(rdr);
                }
            }

            return team;
        }

        private Team RowToObject(SqlDataReader rdr)
        {
            Team team = new Team();

            team.TeamId = Convert.ToInt32( rdr["TeamId"]);
            team.Location = Convert.ToString(rdr["Location"]);
            team.TeamName = Convert.ToString(rdr["TeamName"]);
            team.Conference = (Conference)Convert.ToInt32(rdr["Conference"]);
            team.Division = (Division)Convert.ToInt32(rdr["Division"]);
            team.Wins = Convert.ToInt32(rdr["Wins"]);
            team.Losses = Convert.ToInt32(rdr["Losses"]);
            return team;
        }
    }
}
