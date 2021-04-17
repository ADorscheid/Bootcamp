using States.CLI;
using System;

namespace States
{
    class Program
    {
        /// <summary>
        /// Main should be very short. It's purpose is to "bootstrap" the program to get it going, then 
        /// turn over control to the user interface (MainMenu)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Show();

            Console.WriteLine("Thanks for using our awesome program! Press any key to exit.\r\n\r\n");
        }
    }
}
