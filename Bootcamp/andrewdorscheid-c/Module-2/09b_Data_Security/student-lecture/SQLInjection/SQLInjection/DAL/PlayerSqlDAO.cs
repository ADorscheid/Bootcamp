using System;
using System.Collections.Generic;
using System.Text;
using SQLInjection.Models;
using System.Data.SqlClient;

namespace SQLInjection.DAL
{
    class PlayerSqlDAO : IPlayerDAO
    {
        private string connectionString;
        public PlayerSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Player> SearchPlayer(string name)
        {
            try
            {
                return SearchPlayerTheLAZYWay(name);
            }
            catch (SqlException)
            {
                // TODO: Log this!
                throw;
            }
        }

        private IList<Player> SearchPlayerTheLAZYWay(string name)
        {
            List<Player> list = new List<Player>();
            string cmdText = $"select * from Player where name like '%{name}%'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(RowToObject(rdr));
                }
            }
            return list;
        }

        private IList<Player> SearchPlayerThePROPERWay(string name)
        {
            List<Player> list = new List<Player>();
            string cmdText = $"select * from Player where name like @searchFor";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@searchFor", $"%{name}%");
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(RowToObject(rdr));
                }
            }
            return list;
        }

        private Player RowToObject(SqlDataReader row)
        {
            Player obj = new Player();
            obj.Age = Convert.ToInt32(row["Age"]);
            obj.HeightFeet = Convert.ToInt32(row["HeightFeet"]);
            obj.HeightInches = Convert.ToInt32(row["HeightInches"]);
            obj.Number = Convert.ToInt32(row["Number"]);
            obj.WeightPounds = Convert.ToInt32(row["WeightPounds"]);
            obj.Name = Convert.ToString(row["Name"]);
            obj.Position = Convert.ToString(row["Position"]);
            return obj;
        }
    }
}
