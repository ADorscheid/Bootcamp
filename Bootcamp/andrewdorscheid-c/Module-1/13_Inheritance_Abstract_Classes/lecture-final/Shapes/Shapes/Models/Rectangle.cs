using System;

namespace Shapes.Models
{
    class Rectangle : Shape2D
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public override int Area
        {
            get
            {
                return Height * Width;
            }
        }
        public override int Perimeter
        {
            get
            {
                return (2 * Height) + (2 * Width);
            }
        }

        #region Constructors
        public Rectangle(int x, int y, ConsoleColor color, bool isFilled, int width, int height) :
            base(x, y, color, isFilled)
        {
            Width = width;
            Height = height;
        }
        #endregion

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
            return $"At ({X}, {Y}), a {Color} Rectangle, {Width} X {Height},{(IsFilled ? "" : " not")} filled.";
        }

    }
}
