using System;
using System.Buffers.Binary;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("What is your name?");
            string usersName = Console.ReadLine();
            Console.WriteLine($"Hello {usersName}");

            Console.Write("How tall are you, in inches? ");
            string heightInInchesAsString = Console.ReadLine();
            int heightInInches = int.Parse(heightInInchesAsString);
            Console.WriteLine($"{usersName} is {heightInInches} inches tall.");

            int feet = heightInInches / 12;
            int inches = heightInInches % 12;
            Console.WriteLine($"{usersName} is {feet} feet, {inches} inches tall.");

            Console.Write("Are you wearing plaid today? ");
            string answerToPlaidQuestion = Console.ReadLine();
            bool isWearingFlannel = bool.Parse(answerToPlaidQuestion);

            if (isWearingFlannel) {
                Console.WriteLine("Thanks for participating!");
            } else {
                Console.WriteLine("Maybe next week.");
            }
            */



            /*
            Console.Write("Enter a sentence: ");
            string sentenceInput = Console.ReadLine();

            //split the sentence into words
            string[] words = sentenceInput.Split(" ");
            //print the words, one on each line
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }

            string newSentence = string.Join("-",words);
            Console.WriteLine(newSentence);

            */

            //OBJECTIVE: ask for a series of comma separated numbers and add them 
            //Ask the user for a list of numbers like  "1,2,3,4"
            Console.WriteLine("Enter a series of comma-separated numbers: ");
            string commaSeparatedNumbers = Console.ReadLine();
            
            //split the string into a string array  ["1","2","3","4"]
            string[] stringNumbers = commaSeparatedNumbers.Split(",");


            //loop through the array and convert each item to an int and add them together
            int sum = 0;
            for (int i=0;i<stringNumbers.Length;i++) {
                int currentNumber = int.Parse(stringNumbers[i]);
                sum = sum + currentNumber;
            }
            Console.WriteLine($"The sum is : {sum}");
            

        }
    }
}
