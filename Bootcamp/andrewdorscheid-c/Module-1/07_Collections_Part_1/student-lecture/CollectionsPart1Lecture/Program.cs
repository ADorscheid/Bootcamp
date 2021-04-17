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

			//add more to the end of the list
			characters.Add("Severus");
			characters.Add("Albus");


			Console.WriteLine("####################");
			Console.WriteLine("Lists are ordered");
			Console.WriteLine("####################");
			Console.WriteLine(characters[1]);

			Console.WriteLine("####################");
			Console.WriteLine("Lists allow duplicates");
			Console.WriteLine("####################");
			characters.Add("Harry");


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be inserted in the middle");
			Console.WriteLine("####################");
			characters.Insert(1, "Hagrid");

			//add a array into the list
			string[] slytherins = new string[] { "Draco", "Crabbe", "Goyle"};
			characters.AddRange(slytherins);

			//insert an arry in the middle
			string[] ravenclaw = new string[] { "Luna"};
			characters.InsertRange(7, ravenclaw);


			Console.WriteLine("####################");
			Console.WriteLine("Lists allow elements to be removed by index");
			Console.WriteLine("####################");
			characters.RemoveAt(1);

			
			Console.WriteLine("####################");
			Console.WriteLine("Find out if something is already in the List");
			Console.WriteLine("####################");
            Console.WriteLine($"Is Hermione in the list? {characters.Contains("Hermione")}");

			Console.WriteLine("####################");
			Console.WriteLine("Find index of item in List");
			Console.WriteLine("####################");
			Console.WriteLine($"Where is Draco in the list? {characters.IndexOf("Draco")}");

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be turned into an array");
			Console.WriteLine("####################");
			string[] charactersAsArray = characters.ToArray();

			Console.WriteLine("####################");
			Console.WriteLine("Lists can be sorted");
			Console.WriteLine("####################");
			characters.Sort();
			


			Console.WriteLine("####################");
			Console.WriteLine("Lists can be reversed too");
			Console.WriteLine("####################");
			characters.Reverse();



			Console.WriteLine("####################");
			Console.WriteLine("       FOREACH");
			Console.WriteLine("####################");
			Console.WriteLine();

			//print the list by looping
			for (int i = 0; i < characters.Count; i++)
			{
				Console.WriteLine(characters[i]);
			}

			
			foreach (string character in characters) {
				Console.WriteLine($"{character}");
            }
            Console.WriteLine("-------");
			characters.Clear();
            Console.WriteLine(characters.Count);
			foreach (string character in characters)
			{
				Console.WriteLine($"{character}");
			}



			List<int> scores = new List<int>() { 45,55,65,75};
			for (int i=0;i<scores.Count;i++) {
				if (scores[i]==55) {
					scores.Remove(55);
					i--;
                }
                
            }
		}
	}
}
