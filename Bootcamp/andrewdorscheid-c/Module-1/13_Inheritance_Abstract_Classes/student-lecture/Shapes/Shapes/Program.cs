using System;
using System.Runtime.InteropServices;

namespace Shapes
{
    class Program
    {
        #region This code is advanced code which allows us to Maximize the Console Window on startup
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;
        #endregion

        /* *
         * First, Draw 2D Shapes.  Circle and Rectangle will do the trick, but one can imagine triangles and other polygons.
         * 
         * */

        static void Main(string[] args)
        {
            // Maximize the console
            ShowWindow(ThisConsole, MAXIMIZE);

            DrawingCLI cli = new DrawingCLI();
            cli.Show();

            //Console.WriteLine("Thanks for drawing with us!");
            //Console.ReadKey();
        }
    }
}
