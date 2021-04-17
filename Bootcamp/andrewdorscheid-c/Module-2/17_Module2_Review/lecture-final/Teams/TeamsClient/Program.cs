using System;

namespace TeamsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "https://localhost:44375/";

            MainMenu menu = new MainMenu(baseUrl);
            menu.Show();
        }
    }
}
