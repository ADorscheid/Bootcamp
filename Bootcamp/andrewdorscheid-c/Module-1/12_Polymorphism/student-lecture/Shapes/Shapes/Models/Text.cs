using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models {
    public class Text : IDrawable 
    {
        public string Label { get; set; }
        public ConsoleColor color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Text (int x, int y, ConsoleColor color, string label) 
        {
            this.X = x;
            this.Y = y;
            this.color = color;
            this.Label = label;
        }
        public void Draw()
        {
            Console.CursorLeft = (int)(this.X * Console.WindowWidth / 100.0);
            Console.CursorTop = (int)(this.Y * Console.WindowHeight / 100.0);
            Console.ForegroundColor = this.color;
            Console.WriteLine(this.Label);

            Console.ResetColor();
        }

        public override string ToString()
        {
            return $"At ({X}, {Y}), a {this.color} Label: {this.Label}";
        }

    }
}
