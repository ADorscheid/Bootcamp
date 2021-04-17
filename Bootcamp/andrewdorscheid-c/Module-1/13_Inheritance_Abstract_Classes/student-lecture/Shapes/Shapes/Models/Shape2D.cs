using System;

namespace Shapes.Models
{
    /**************************************************
    * Until now, we have been Drawing Shape2D objects (including anything that IS A Shape2D by inheritance).  But we
    * need to include other drawable things which are not 2D shapes, like text, sprites and lines.  So we defined an 
    * IDrawable interface to say what a class CAN DO.  
    **************************************************/

    // TODO 03: Should Shape2D be concrete? WHat would it look like, how would you draw it?
    /// <summary>
    /// A two-dimensional shape that can be drawn on the screen
    /// </summary>
    public abstract class Shape2D : IDrawable
    {
        #region statics
        public static char edgeSymbol = '*';
        public static char fillSymbol = '*'; //'█';
        protected const double ASPECT_ADJUSTMENT = 0.45;
        #endregion

        #region Properties
        public bool IsFilled { get; set; }
        public ConsoleColor Color { get; set; }
        // Location of the shape
        public int X { get; set; }
        public int Y { get; set; }

        // TODO 01: We don't know how to calculate Area and Perimeter, so force any inheriting class to implement these properties.
        virtual public int Area
        {
            get
            {
                return 0;
            }
        }

        abstract public int Perimeter
        {
            get;
        }

        #endregion

        #region Fields
        // A place to save the current color for restoring after the draw
        private ConsoleColor savedColor = ConsoleColor.White;
        #endregion

        #region Constructors
        public Shape2D(int x, int y, ConsoleColor color, bool isFilled)
        {
            X = x;
            Y = y;
            this.Color = color;
            this.IsFilled = isFilled;
        }
        #endregion

        #region Public Methods

        // TODO 02: Draw makes no sense at the Shape2D level, so force any inheriting class to implement it.
        abstract public void Draw();

        public override string ToString()
        {
            return $"A shape with Area={Area} and Perimeter={Perimeter}";
        }
        #endregion

        #region Helper Methods
        protected void SetConsoleColor()
        {
            this.savedColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
        }

        protected void ResetConsoleColor()
        {
            Console.ForegroundColor = savedColor;
        }
        #endregion
    }
}

