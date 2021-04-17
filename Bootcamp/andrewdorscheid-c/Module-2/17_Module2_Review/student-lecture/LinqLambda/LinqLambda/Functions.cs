using System;
using System.Collections.Generic;

namespace LinqLambda
{
    public class Functions
    {
        public void ExecuteFunctions()
        {
            int result = 0;
            // Create a method (function) called DoubleIt, then call it and display its results

            Console.WriteLine($"DoubleIt(4) = {result}");

            // Create another variable which can hold a reference to the DoubleIt method. Then invoke that.

            Console.WriteLine($"anotherName(12) = {result}");

            // Declare the TripleIt variable as a function and define its body

            Console.WriteLine($"TripleIt(14) = {result}");

            // Do the same with the QuadrupleIt function, using some shortcuts.

            Console.WriteLine($"QuadrupleIt(15) = {result}");

            // Declare an array to use for testing
            int[] arr = new int[] { 2, 4, 7, 9 };

            // Call the ForEach method, passing the functionToApply in different ways
            PrintArray(arr);
            //PrintArray(ForEach(arr, DoubleIt));
            //PrintArray(ForEach(arr, n => n * 5));
        }

        private void PrintArray(IEnumerable<int> arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        // Create a method (function) called DoubleIt


        // Create a ForEach method, which takes 2 parameters: an array of ints, and a function<int, int> 
        // to apply to every element in the array. This method returns an array of the results.

    }
}
