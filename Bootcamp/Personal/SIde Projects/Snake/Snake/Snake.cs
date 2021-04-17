using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Snake
    {
        public int SnakeLength { get; set; }
        
        public Snake()
        {
            // snake starts out with some length
            this.SnakeLength = 2;
        }
    }
}
