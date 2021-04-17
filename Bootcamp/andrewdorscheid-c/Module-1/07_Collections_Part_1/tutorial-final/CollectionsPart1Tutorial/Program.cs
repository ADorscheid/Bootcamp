using System;
using System.Collections.Generic;

namespace CollectionsPart1Tutorial
{
    public class CollectionsPart1Tutorial
    {
        static void Main(string[] args)
        {
            // Step One: Declare a List
            List<string> nameList = new List<string>();


            // Step Two: Add values to a List
            nameList.Add("Ada");
            nameList.Add("Grace");
            nameList.Add("Margaret");
            nameList.Add("Adele");


            // Step Three: Looping through a List in a for loop
            for (int i = 0; i < nameList.Count; i++)
            {
                Console.WriteLine("The name at index " + i + " is " + nameList[i]);
            }


            // Step Four: Remove an item
            nameList.Remove("Ada");  // or nameList.RemoveAt(0);


            // Step Five: Looping through List in a foreach loop
            foreach (string name in nameList)
            {
                Console.WriteLine("Name: " + name);
            }
        }
    }
}
