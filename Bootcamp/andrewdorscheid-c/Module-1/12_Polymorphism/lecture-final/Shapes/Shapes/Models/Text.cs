using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    public class Text : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Label { get; set; }
        public ConsoleColor Color { get; set; }

        public Text(int x, int y, ConsoleColor color, string label)
        {
            X = x;
            Y = y;
            Color = color;
            Label = label;
        }

        public void Draw()
        {
            Console.CursorLeft = (int)(X * Console.WindowWidth / 100.0);
            Console.CursorTop = (int)(Y * Console.WindowHeight / 100.0);

            // Set the color
            Console.ForegroundColor = Color;

            // Write the text on the screen
            Console.Write(Label);

            // Reset the screen color
            Console.ResetColor();

        }

        public override string ToString()
        {
            return $"At ({X}, {Y}), a {Color} Label, with value '{Label}'";
        }
    }
}
