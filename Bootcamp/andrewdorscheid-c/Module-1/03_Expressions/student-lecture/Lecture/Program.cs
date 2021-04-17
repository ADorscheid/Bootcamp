using System;

namespace Lecture
{
    class Program
    {
        static bool sticky1(bool a) {
            Console.WriteLine("in sticky1");
            return a;
        }
        static bool sticky2(bool b) {
            Console.WriteLine("in sticky2");
            return b;
        }
        static bool sticky3(bool c) {
            Console.WriteLine("in sticky3");
            return c;
        }
        static void Main(string[] args)
        {
            bool a = true;
            bool b = true;
            bool c = true;
            if (sticky1(a) && sticky2(b) || sticky3(c)) {
                Console.WriteLine("in IF");
            }
            Console.WriteLine("done");
            /*****************************************************************************
            Part 1: Variable Scope
            ******************************************************************************/
            // Declare a variable

            // Start a statement block

            // Print out the variable defined in the outer scope

            // Declare a variable in the block (inner scope)

            // Print out that variable

            // End the statement block

            // Print the the variable declared in the block


            /*****************************************************************************
            Part 2: Methods
            ******************************************************************************/
            // Call the MultiplyBy method


            // Create and print some boolean expressions


        }

        /*
         * Create a method called MultiplyBy, which takes two integers and returns the integer product.
         */
    }
}
