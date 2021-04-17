using System;
using System.Collections.Generic;

namespace CollectionsPart1Lecture
{
    public class CollectionsPart1Lecture
    {
        static void Main(string[] args)
        {
            Console.WriteLine("####################");
            Console.WriteLine("       LISTS");
            Console.WriteLine("####################");

            List<string> characters;
            characters = new List<string>()
            {
                "Harry",
                "Ron",
                "Hermione"
            };

            List<int> scores = new List<int>() { 90, 57, 67, 100, 87, 72 };
            scores.Add(99);

            // Print using Join
            Console.WriteLine(string.Join(" - ", scores));

            // Add another character to the end of the list
            characters.Add("Severus");
            characters.Add("Albus");

            // Print the list by looping and CW
            for (int i = 0; i < characters.Count; i++)
            {
                Console.WriteLine(characters[i]);
            }


            Console.WriteLine("####################");
            Console.WriteLine("Lists are ordered");
            Console.WriteLine("####################");


            Console.WriteLine("####################");
            Console.WriteLine("Lists allow duplicates");
            Console.WriteLine("####################");

            //characters.Add("Harry");




            Console.WriteLine("####################");
            Console.WriteLine("Lists allow elements to be inserted in the middle");
            Console.WriteLine("####################");
            characters.Insert(1, "Hagrid");

            scores.Insert(0, 95);
            // Print using Join
            Console.WriteLine(string.Join(" - ", scores));

            // TODO: Add multiple values at once
            string[] slitheren = new string[] { "Draco", "Crab", "Goyle" };
            //characters.AddRange(slitheren);
            characters.InsertRange(4, slitheren);

            Console.WriteLine("####################");
            Console.WriteLine("Lists allow elements to be removed by index");
            Console.WriteLine("####################");
            characters.RemoveAt(1);

            scores.RemoveAt(0);


            // Remove by value
            characters.Remove("Hermione");

            scores.Remove(87);

            Console.WriteLine("####################");
            Console.WriteLine("Find out if something is already in the List");
            Console.WriteLine("####################");

            Console.WriteLine($"Is there still an 87? {scores.Contains(87)}");

            Console.WriteLine($"Is Hermione in the list? {characters.Contains("Hermione")}");
            Console.WriteLine($"Is Draco in the list? {characters.Contains("Draco")}");


            Console.WriteLine("####################");
            Console.WriteLine("Find index of item in List");
            Console.WriteLine("####################");
            Console.WriteLine($"Where is Hermione in the list? {characters.IndexOf("Hermione")}");
            Console.WriteLine($"Where is Draco in the list? {characters.IndexOf("Draco")}");


            Console.WriteLine("####################");
            Console.WriteLine("Lists can be turned into an array");
            Console.WriteLine("####################");
            string[] charactersAsArray = characters.ToArray();

            // Create a new list from that array
            List<string> newlist = new List<string>(charactersAsArray);

            Console.WriteLine("####################");
            Console.WriteLine("Lists can be sorted");
            Console.WriteLine("####################");

            Console.WriteLine(string.Join(",", characters));

            characters.Sort();
            characters.Reverse();
            Console.WriteLine(string.Join(",", characters));

            // Sort the scores

            // Print using Join
            Console.WriteLine(string.Join(" - ", scores));
            scores.Sort();
            // Print using Join
            Console.WriteLine(string.Join(" - ", scores));



            Console.WriteLine("####################");
            Console.WriteLine("Lists can be reversed too");
            Console.WriteLine("####################");


            Console.WriteLine("####################");
            Console.WriteLine("       FOREACH");
            Console.WriteLine("####################");
            Console.WriteLine();

            // Print all of the characters

            // The classic way...
            for (int i = 0; i < characters.Count; i++)
            {
                string character = characters[i];
                Console.WriteLine(character);
            }
            Console.WriteLine("==============================================");
            // The "foreach" way...
            foreach (string character in characters)
            {
                Console.WriteLine(character);
            }

            // Clear the list
            characters.Clear();

            // Print the list
            Console.WriteLine("==============================================");
            Console.WriteLine("Here are the new values:");
            foreach (string character in characters)
            {
                Console.WriteLine(character);
            }


            //scores.Clear();

            // Add up all the scores and display an average
            int sum = 0;
            foreach (int score in scores)
            {
                sum += score;
            }
            Console.WriteLine($"Total: {sum}, Average score: { (double)sum / scores.Count }");


            // Remove all the values < 75
            //foreach(int score in scores)
            //         {
            //	if (score < 75)
            //             {
            //		scores.Remove(score);
            //             }
            //         }

            for (int i = 0; i < scores.Count; i++)
            {
                if (scores[i] < 75)
                {
                    scores.RemoveAt(i);
                    i--;
                }
            }

        }
    }
}
