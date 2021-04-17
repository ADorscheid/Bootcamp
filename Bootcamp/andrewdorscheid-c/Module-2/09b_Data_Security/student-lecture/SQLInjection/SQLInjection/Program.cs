using SQLInjection.DAL;
using SQLInjection.Models;
using System;
using System.Collections.Generic;

namespace SQLInjection
{
    class Program
    {
        static void Main(string[] args)
        {

            /*** 
             * Whatever you do, do NOT type this in:
             *      O'Malley
             *      '; Delete Player where Number = 22; --
             *      '; Update Player Set Name = 'Mike Morel' where Number = 12; --
             *      '; Drop table Player; --
             *      
             ***/

            string cs = "Server=.\\SQLEXPRESS;Database=RosterDB;Trusted_Connection=True;";
            IPlayerDAO dao = new PlayerSqlDAO(cs);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Employee Search");
                Console.Write("Please enter a name to search for (QQ to Quit):");
                string searchString = Console.ReadLine();
                if (searchString.ToLower() == "qq")
                {
                    break;
                }
                IList<Player> players = dao.SearchPlayer(searchString);

                foreach (Player player in players)
                {
                    Console.WriteLine(player.ToString());
                }
                Console.Write("Press Any Key to continue");
                Console.ReadKey();
            }
            //select * from employee where last_name like '%son' OR 1 = 1-- % '

            //select * from employee where last_name like '%son' OR 1 = 1; select @@VERSION-- % '

        }
    }
}
