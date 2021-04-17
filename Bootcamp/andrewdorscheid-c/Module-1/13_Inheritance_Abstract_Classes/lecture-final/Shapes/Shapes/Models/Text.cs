using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    /**********************
    * Create a Text class that is IDrawable.  Implement the interface.
    * This is a Text class which displays a string on the screen.
    * It IS NOT a 2D Shape (does not have an area or perimeter for instance).  So we use the IDrawwable 
    * interface to say that indeed we "CAN" draw this class on a screen.
    * Text should have:
    *   * X, Y, Color, Label
    *   * A constructor that takes the 4 properties above
    *   * An override of ToString for the Listing
    * 
    **********************/
    public class Text : IDrawable
    {
        public string Label { get; set; }
        public ConsoleColor Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Text(int x, int y, ConsoleColor color, string label)
        {
            X = x;
            Y = y;
            Color = color;
            Label = label;
        }
        public void Draw()
        {
            // Calculate where on the screen to set the cursor before we write the text
            Console.CursorTop = (int)(this.Y * Console.WindowHeight / 100.0);
            Console.CursorLeft = (int)(this.X * Console.WindowWidth / 100.0);

            // Set the color
            Console.ForegroundColor = Color;

            // Write the text
            Console.Write(Label);

            // Reset the color
            Console.ResetColor();
        }
        public override string ToString()
        {
            return $"At ({X}, {Y}), a {Color} Label with text '{Label}'.";
        }
    }
}
