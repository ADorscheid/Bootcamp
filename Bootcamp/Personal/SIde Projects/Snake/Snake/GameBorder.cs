using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class GameBorder
    {
        public int Size
        {
            get
            {
                return this.SideLength * this.SideLength;
            }
        }
        public int SideLength { get; }
        public int fruitX { get; set; }
        public int fruitY { get; set; }

        public GameBorder(int sideLength, Fruit fruit)
        {
            this.SideLength = sideLength;
            this.fruitX = fruit.X;
            this.fruitY = fruit.Y;
        }

        /*public void PlaceFruit(Fruit fruit)
        {
            this.fruitX = fruit.X;
            this.fruitY = fruit.Y;
        }*/

        public void PrintGameBoard()
        {
            //two for loops that prints the board
            //| is the left and right walls
            //—— is the top and bottom walls (2 —'s)
            //the middle of the board (not edges) are TWO spaces
            for (int i = 0; i <= this.SideLength; i++)
            {
                for (int j = 0; j <= this.SideLength; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("|");
                    }
                    if (i == 0 || i == this.SideLength)
                    {
                        Console.Write("——");
                    }
                    else
                    {
                        if (i == this.fruitX && j == this.fruitY)
                        {
                            Console.Write("[]");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    if (j == this.SideLength)
                    {
                        Console.Write("|");
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
}
