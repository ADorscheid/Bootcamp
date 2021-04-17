using MenuFramework;
using Shapes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes
{
    /*************************************************************************
     * Try this:
        At (20, 10), a White Rectangle, 70 X 80, filled.
        At (55, 50), a Red Circle with radius 25, filled.
        At (10, 10), a DarkGray Rectangle, 8 X 90, filled.
        At (14, 3), a Blue Circle with radius 8, filled.

     * ***********************************************************************/
    class DrawingCLI : ConsoleMenu
    {
        #region Fields

        // TODO 10 Create the private list of shapes. 
        // This is our "drawing"; it is what the user is building up while running the program.
        List<Shape2D> shapes = new List<Shape2D>();

        #endregion

        /// <summary>
        /// This class derives from ConsoleMenu. In the constructor, we add all of the "options"
        /// on this menu.
        /// </summary>
        public DrawingCLI()
        {
            this.AddOption("Add a Circle", AddCircle)
                .AddOption("Add a Rectangle", AddRectangle)
                .AddOption("Draw the Canvas", DrawCanvas)
                .AddOption("List All Shapes", ListShapes)
                .AddOption("Clear the Canvas", ClearCanvas)
                .AddOption("Quit", Exit, "Q")
                .Configure(cfg =>
               {
                   cfg.Title = "Shapes! Drawing Program";
                   cfg.ItemForegroundColor = ConsoleColor.Yellow;
                   cfg.SelectedItemForegroundColor = ConsoleColor.Green;
                   cfg.MenuSelectionMode = MenuSelectionMode.Arrow;
               });
        }

        /// <summary>
        /// In a ConsoleMenu, we can override OnBeforeShow to display anything we want before the menu is drawn.
        /// (Similarly, there is a OnAfterShow to display stuff after the menu options.)
        /// </summary>
        protected override void OnBeforeShow()
        {
            Console.WriteLine("███████╗██╗  ██╗ █████╗ ██████╗ ███████╗███████╗██╗");
            Console.WriteLine("██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝██╔════╝██║");
            Console.WriteLine("███████╗███████║███████║██████╔╝█████╗  ███████╗██║");
            Console.WriteLine("╚════██║██╔══██║██╔══██║██╔═══╝ ██╔══╝  ╚════██║╚═╝");
            Console.WriteLine("███████║██║  ██║██║  ██║██║     ███████╗███████║██╗");
            Console.WriteLine("╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝╚══════╝╚═╝");
        }

        #region Menu Action Methods

        private MenuOptionResult AddCircle()
        {
            // Prompt the user for X, Y, Radius, Color and Filled, then add a Circle
            int x = GetInteger("Center (X): ", null, Enumerable.Range(0, 100));
            int y = GetInteger("Center (Y): ", null, Enumerable.Range(0, 100));
            int radius = GetInteger("Radius: ", 1, Enumerable.Range(1, 50));
            ConsoleColor color = GetColor();
            bool filled = GetBool("Do you want the shape filled? ", false);

            // TODO 11 Add a new Circle to the collection
            Circle circle = new Circle(x, y, color, filled, radius);
            shapes.Add(circle);


            Console.WriteLine("New Circle was added");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult AddRectangle()
        {
            // Prompt the user for X, Y, Width, Height, Color and Filled, then add a Rectangle
            int x = GetInteger("Left (X): ", null, Enumerable.Range(0, 100));
            int y = GetInteger("Top (Y): ", null, Enumerable.Range(0, 100));
            int width = GetInteger("Width: ", null, Enumerable.Range(1, 100));
            int height = GetInteger("Height: ", null, Enumerable.Range(1, 100));
            ConsoleColor color = GetColor();
            bool filled = GetBool("Do you want the shape filled? ", false);

            // TODO 12 Add a new Rectangle to the collection
            shapes.Add( new Rectangle(x, y, color, filled, width, height) );

            Console.WriteLine("New Rectangle was added");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        /// <summary>
        /// Draw all the shapes onto the canvas (Console)
        /// </summary>
        private MenuOptionResult DrawCanvas()
        {
            // TODO 13 Loop through the shapes and Draw each one.
            foreach(Shape2D shape in shapes)
            {
                shape.Draw();
            }

            // Hide the cursor while displaying the drawing
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CursorVisible = true;
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        private MenuOptionResult ListShapes()
        {
            Console.WriteLine("Shapes:");

            // TODO 14 Display the list of shapes
            foreach(Shape2D shape in shapes)
            {
                // If you pass an object "obj" into CW, CW calls obj.ToString() to determine what to display
                Console.WriteLine(shape);
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ClearCanvas()
        {
            // TODO 15 Clear the list of shapes
            shapes.Clear();

            // Another way to clear the list...
            //shapes = new List<Shape2D>();

            Console.WriteLine("Canvas was cleared");
            return MenuOptionResult.WaitAfterMenuSelection;
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// This method prompts the user for color and makes sure the value is a valid ConsoleColor.
        /// </summary>
        /// <returns>ConsoleColor selected by the user</returns>
        private ConsoleColor GetColor()
        {
            string colorString = GetString("Color: ", false, "White", Enum.GetNames(typeof(ConsoleColor)));
            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorString, true);
            return color;
        }
        #endregion
    }
}
