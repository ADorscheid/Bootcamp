using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    public class Rectangle : Shape2D
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override int Area
        {
            get
            {
                return Width * Height;
            }
        }

        public override int Perimeter
        {
            get
            {
                return (2 * Width) + (2 * Height);
            }
        }

        public Rectangle(int x, int y, ConsoleColor color, bool isFilled, int width, int height) : base(x, y, color, isFilled)
        {
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            SetConsoleColor();

            #region Do the math to calculate which symbols to draw

            // Calculate the top as a ratio of total height of the window
            int top = (int)(this.Y * Console.WindowHeight / 100.0);
            int left = (int)(this.X * Console.WindowWidth / 100.0);
            int heightLines = (int)(this.Height * Console.WindowHeight / 100.0);
            int widthCharacters = (int)(this.Width * Console.WindowWidth / 100.0);
            for (int y = 1; y <= heightLines; y++)
            {
                Console.CursorTop = top + y;
                string output;

                // Adjust the width based on the Skew factor
                if (y == 1 || y == heightLines)
                {
                    // first and last line
                    output = new string(edgeSymbol, widthCharacters);
                }
                else
                {
                    output = edgeSymbol + new string(IsFilled ? fillSymbol : ' ', Math.Max(widthCharacters - 2, 0)) + edgeSymbol;
                }
                Console.CursorLeft = left;
                Console.Write(output);
            }
            #endregion

            ResetConsoleColor();

        }
        public override string ToString()
        {
            return $"A {Color} Rectangle with dimension {Width} x {Height}, at location ({X}, {Y}).";
        }

    }
}
