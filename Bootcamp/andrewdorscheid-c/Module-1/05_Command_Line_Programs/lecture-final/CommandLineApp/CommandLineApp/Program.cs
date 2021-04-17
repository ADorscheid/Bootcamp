using System;

namespace CommandLineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Ask the user for their name
            //Console.Write("Hello, what is your name? ");

            //// Get the user's name
            //string name = Console.ReadLine();

            //// Greet the user
            //Console.WriteLine($"Well hello there, {name}!");

            //// Ask for height
            //Console.Write("How tall are you in inches? ");

            //// Read height from user
            //string heightAsString = Console.ReadLine();
            //int heightInches = int.Parse(heightAsString);

            //// calculate the height in feet and inches..
            //int feet = heightInches / 12;
            //int inches = heightInches % 12;

            //Console.WriteLine($"Wow, did you know that is {feet} feet and {inches} inches?");

            //// Ask if the user is wearing flannel
            //Console.Write("Are you wearing flannel right now (true / false)?");
            //string input = Console.ReadLine();
            //bool isWearingFlannel = bool.Parse(input);


            //// If they are, and they are over 6 feet, we will tell them they look like a lumberjack/jill
            //if (isWearingFlannel)
            //{
            //    Console.WriteLine("Thanks for participating!");
            //}
            //else
            //{
            //    Console.WriteLine("Maybe next week!");
            //}
            // 


            // Ask the user for a sentence
            //Console.Write("Enter a sentence: ");
            //string sentence = Console.ReadLine();

            //// Split the sentence into words, and print one word on each line
            //string[] words = sentence.Split(" ");

            //for (int i = 0; i < words.Length; i++)
            //{
            //    Console.WriteLine(words[i]);
            //}

            //string newSentence = string.Join("---", words);
            //Console.WriteLine(newSentence);


            while (true)
            {
                // Ask for a series of comma-separated numbers, add them up and tell the user the SUM

                // Prompt the user for a list of cs-numbers  "10,45,32,56"
                Console.Write("Enter a series of comma-separated numbers (Q to quit) ");
                string input = Console.ReadLine();

                // Did the user type Q?
                if (input == "Q")
                {
                    // Break out of the loop
                    break;
                }

                // Split the string into an array of "string-numbers"    ["10","45","32","56"]
                string[] stringNumbers = input.Split(",");

                // Initialize a "SUM" to 0
                int sum = 0;

                // Loop through the array of string-numbers
                for (int i = 0; i < stringNumbers.Length; i++)
                {
                    // Parse the element into an int
                    int num = int.Parse(stringNumbers[i]);

                    // Add the value to the SUM
                    sum += num;
                }
                // Once the loop is finished, tell the user the SUM
                Console.WriteLine($"These numbers add up to {sum}.");
            }

            Console.WriteLine("Goodbye");

        }
    }
}
