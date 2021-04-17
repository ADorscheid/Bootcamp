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
        /****************** Polymorphism and Interfaces ********************
         * TODO 02 Update the shapes collection to hold IDrawable objects 
         * (we should rename it to)
        ********************************************************************/

        List<IDrawable> drawables = new List<IDrawable>();
        #endregion

        public DrawingCLI()
        {
            // TODO 06 Add "Add a Text object" to the menu and handle the choice (call AddText)

            // TODO 08 Add "Get total area" to the menu (call ShowTotalArea)

            this.AddOption("Add a Circle", AddCircle)
                .AddOption("Add a Rectangle", AddRectangle)
                .AddOption("Add Text", AddText)
                .AddOption("Draw the Canvas", DrawCanvas)
                .AddOption("List All Shapes", ListShapes)
                .AddOption("Get Total Area of All Shapes", GetTotalArea)
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

        protected override void OnBeforeShow()
        {
            Console.WriteLine("███████╗██╗  ██╗ █████╗ ██████╗ ███████╗███████╗██╗");
            Console.WriteLine("██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝██╔════╝██║");
            Console.WriteLine("███████╗███████║███████║██████╔╝█████╗  ███████╗██║");
            Console.WriteLine("╚════██║██╔══██║██╔══██║██╔═══╝ ██╔══╝  ╚════██║╚═╝");
            Console.WriteLine("███████║██║  ██║██║  ██║██║     ███████╗███████║██╗");
            Console.WriteLine("╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝╚══════╝╚═╝");
        }

        private MenuOptionResult AddCircle()
        {
            int x = GetInteger("Center (X): ", null, Enumerable.Range(0, 100));
            int y = GetInteger("Center (Y): ", null, Enumerable.Range(0, 100));
            int radius = GetInteger("Radius: ", 1, Enumerable.Range(1, 50));
            ConsoleColor color = GetColor();
            bool filled = GetBool("Do you want the shape filled? ", false);
            drawables.Add(new Circle(x, y, color, filled, radius));
            Console.WriteLine("New Circle was added");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult AddRectangle()
        {
            int x = GetInteger("Left (X): ", null, Enumerable.Range(0, 100));
            int y = GetInteger("Top (Y): ", null, Enumerable.Range(0, 100));
            int width = GetInteger("Width: ", null, Enumerable.Range(1, 100));
            int height = GetInteger("Height: ", null, Enumerable.Range(1, 100));
            ConsoleColor color = GetColor();
            bool filled = GetBool("Do you want the shape filled? ", false);
            drawables.Add(new Rectangle(x, y, color, filled, width, height));
            Console.WriteLine("New Rectangle was added");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private ConsoleColor GetColor()
        {
            string colorString = GetString("Color: ", false, "White", Enum.GetNames(typeof(ConsoleColor)));
            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorString, true);
            return color;
        }

        /// <summary>
        /// Draw all the shapes onto the canvas (Console)
        /// </summary>
        private MenuOptionResult DrawCanvas()
        {
            // TODO 04 We no longer draw shapes.  We draw "things that are drawable"
            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw();
            }
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CursorVisible = true;
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        private MenuOptionResult ListShapes()
        {
            // TODO 04 We no longer draw shapes.  We draw "things that are drawable"
            Console.WriteLine("Drawables:");
            foreach (IDrawable drawable in drawables)
            {
                Console.WriteLine($"\t{drawable}");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ClearCanvas()
        {
            drawables.Clear();

            Console.WriteLine("Canvas was cleared");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        /********************************************
        * TODO 07: Create method *private MenuOptionResult AddText()*
        *          1. Prompt the user for the text location (x and y)
        *          1. Prompt the user for the text label
        *          2. Prompt the user for the text color
        *          3. Create the new Text object
        *          4. Add the new Text object to the list of drawables
        *          5. Report success to the user
        ********************************************/
        private MenuOptionResult AddText()
        {
            int x = GetInteger("Left (X): ", null, Enumerable.Range(0, 100));
            int y = GetInteger("Top (Y): ", null, Enumerable.Range(0, 100));
            ConsoleColor color = GetColor();
            string label = GetString("Label Text:");
            drawables.Add(new Text(x, y, color, label));
            Console.WriteLine("New Text was added");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        /********************************************
        * TODO 08: Create method to "Get total area" 
        *       private MenuOptionResult ShowTotalArea()
        *   and report it to the user
        ********************************************/
        public MenuOptionResult GetTotalArea() {
            int totalArea = 0;
            foreach (IDrawable drawable in this.drawables) {
                if (drawable is Shape2D) {
                    Shape2D shape = (Shape2D)drawable;
                    totalArea += shape.Area;
                }    
            }
            Console.WriteLine($"Total Area: {totalArea}");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

    }
}
