using System;
using Figgle;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string stuff = FiggleFonts.DefLeppard.Render("Def Leppard");
            Console.WriteLine(stuff);

            MainMenu menu = new MainMenu();
            menu.Show();

            Console.WriteLine("****** DONE! *************");
        }
    }
}
