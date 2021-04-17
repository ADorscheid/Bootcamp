using System;
using System.Collections.Generic;
using Interfaces.Classes;
namespace Interfaces
{
    class Program
    {
        //static char[] digitChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        // This sample program implements the IEnumerable / IEnumerator interfaces in creative ways
        static void Main(string[] args)
        {
            // IComparable
            SortPeople();


            //Sentence sentence = new Sentence("");
            //foreach (string word in sentence)
            //{
            //    Console.WriteLine($"Word: {word}");
            //}
            ////Sentence sentence = new Sentence("The quick brown fox jumped over the lazy dog.");
            ////foreach (string word in sentence)
            ////{
            ////    Console.WriteLine($"Word: {word}");
            ////}

            //Fibonacci fib = new Fibonacci(1000);
            //foreach (int n in fib)
            //{
            //    Console.WriteLine(n);
            //}

            //Digits digits = new Digits(98734567, 10);
            //foreach (char digit in digits)
            //{
            //    Console.Write(digit);
            //}
            //Console.WriteLine();
            //Console.WriteLine("====================================");

            //digits = new Digits(1010, 16);
            //foreach (char digit in digits)
            //{
            //    Console.Write(digit);
            //}
            //Console.WriteLine();
            //Console.WriteLine("====================================");

            //digits = new Digits(99, 2);
            //foreach (char digit in digits)
            //{
            //    Console.Write(digit);
            //}
            //Console.WriteLine();
            //Console.ReadKey();
        }

        static private void SortPeople()
        {
            List<string> people = new List<string>()
            {
                "Mike Morel", "Peggy Collins", "Doug Clarke", "Andrew Quandt"
            };

            //List<Person> people = new List<Person>()
            //{
            //    new Person("Mike", "Morel", 57, 71),
            //    new Person("Peggy", "Collins", 50, 62),
            //    new Person("Doug", "Clarke", 58, 74),
            //    new Person("Andrew", "Quandt", 25, 69)
            //};
            DisplayList(people);

            // Sort
            people.Sort();
            DisplayList(people);

            Console.ReadLine();
        }
        static void DisplayList(List<string> people)
        {
            Console.WriteLine("People:");
            foreach (string name in people)
            {
                Console.WriteLine($"\t{name}");
            }
        }
        static void DisplayList(List<Person> people)
        {
            Console.WriteLine("People:");
            foreach (Person person in people)
            {
                Console.WriteLine($"\t{person}");
            }
        }
    }
}
