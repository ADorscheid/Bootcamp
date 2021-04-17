using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Fruit
    {
        public int X { get; set; }
        public int Y { get; set; }
        private static Random RD = new Random();


        public Fruit(int gameSize)
        {
            //putting in random number between offset and gameSize-offset so the fruit wont end up directly on the edge(that would be very hard to not run into a wall)
            int offset = 1;
            this.X = RD.Next(offset, gameSize-offset);
            this.Y = RD.Next(offset, gameSize-offset);
        }

    }
}
