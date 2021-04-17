using System;
using System.Runtime.InteropServices;

namespace Shapes
{

    // TODO 01 Create a Shape class with the appropriate methods and properties
    //      Properties: X, Y, Color, IsFilled, Area, Perimeter
    //      Methods: Draw, ToString
    // TODO 02 Create a subclass for Circle and provide the appropriate implementations
    // TODO 03 Create a subclass for Rectangle and provide the appropriate implementations

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
         * Draw 2D Shapes on a "canvas".  Circle and Rectangle will do the trick, but one can imagine triangles and other polygons.
         * */
        static void Main(string[] args)
        {
            // Maximize the console
            ShowWindow(ThisConsole, MAXIMIZE);

            DrawingCLI menu = new DrawingCLI();
            menu.Show();

            Console.WriteLine("Thanks for drawing with us!");
            Console.ReadKey();
        }
    }
}
