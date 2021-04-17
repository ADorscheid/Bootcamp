using System;
using System.Collections.Generic;
using System.Text;
using MenuFramework;
namespace Demo
{
    public class MainMenu : ConsoleMenu
    {
        public MainMenu()
        {
            AddOption("Get the current time", GetTime);
            AddOption("Get the weather", GetWeather);
            AddOption("Quit", Exit);
        }

        private MenuOptionResult GetWeather()
        {
            Console.WriteLine("Flippin' Cold!");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult GetTime()
        {
            Console.WriteLine(DateTime.Now);
            return MenuOptionResult.WaitAfterMenuSelection;
        }

    }
}
