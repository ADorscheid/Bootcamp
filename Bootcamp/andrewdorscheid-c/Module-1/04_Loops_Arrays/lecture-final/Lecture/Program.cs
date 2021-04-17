using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Use a for-loop to print "Hello World" 10 times

            // for ( "initialize a varable"; "while this is true, run the loop"; "do this after each time through the loop")

            for (int i = 1; i <= 10; i = i + 1)
            {
                Console.WriteLine("Hello World!");
            }



            // 2. Create an array of quiz scores
            int[] scores = new int[] {94, 87, 100, 66, 75};

            // 3. Print all the scores to the screen
            for (int i = 0; i < scores.Length; i += 1)
            {
                Console.WriteLine($"Score = {scores[i]}");
            }

            // 4. Grade on a curve...increase all scores by the curve amount
            int curveAmount = 7;
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] += curveAmount;
                Console.WriteLine($"{i+1} Score = {scores[i]}");
            }

            // 5. Calculate and print the average score for the class after the curve.

            // Create a variable for the total of all scores.  Declare it BEFORE the loop.
            int runningTotal = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                // In the loop, add each score to the total
                runningTotal += scores[i];
            }

            // After the loop is done, divide the total by the length of the array
            double averageScore = runningTotal / (double)scores.Length;

            Console.WriteLine($"Average score is {averageScore:n2}");

        }

    }
}
