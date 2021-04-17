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

        /****************** Polymorphism and Interfaces ********************
        * TODO 01 Define an IDrawable interface, which contains one method: Draw,
        *           and two properties, X and Y
        * 
        ********************************************************************/

        /**********************
        * TODO 05 Create a Text class that is IDrawable.  Implement the interface.
        * This is a Text class which displays a string on the screen.
        * It IS NOT a 2D Shape (does not have an area or perimeter for instance).  So we use the IDrawwable 
        * interface to say that indeed we "CAN" draw this class on a screen.
        * Text should have:
        *   * X, Y, Color, Label
        *   * A constructor that takes the 4 properties above
        *   * An override of ToString for the Listing
        * 
        **********************/


        static void Main(string[] args)
        {
            // Maximize the console
            ShowWindow(ThisConsole, MAXIMIZE);

            DrawingCLI cli = new DrawingCLI();
            cli.Show();

            Console.WriteLine("Thanks for drawing with us!");
            Console.ReadKey();
        }
    }
}
