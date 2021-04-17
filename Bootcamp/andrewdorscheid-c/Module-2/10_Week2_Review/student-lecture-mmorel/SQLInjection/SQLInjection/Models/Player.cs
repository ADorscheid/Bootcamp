using System;
using System.Collections.Generic;
using System.Text;

namespace SQLInjection.Models
{
    public class Player
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int HeightFeet { get; set; }
        public int HeightInches { get; set; }
        public int WeightPounds { get; set; }

        public override string ToString()
        {
            return $"{Number,2} {Name,-20}  {Position,2}   {Age,2} yr   {HeightFeet}'{HeightInches,2}\"  {WeightPounds} lbs.";
        }
    }

}
