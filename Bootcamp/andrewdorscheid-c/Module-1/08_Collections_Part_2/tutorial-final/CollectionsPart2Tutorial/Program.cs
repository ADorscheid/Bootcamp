using System;
using System.Collections.Generic;

namespace CollectionsPart2Tutorial
{
    public class CollectionsPart2Tutorial
    {
        static void Main(string[] args)
        {

            // Step One: Declare a Dictionary
            Dictionary<string, string> projects = new Dictionary<string, string>();


            // Step Two: Add items to a Dictionary
            projects["Ada"] = "Inventing Computer Programming";
            projects["Grace"] = "COBOL";
            projects["Margaret"] = "Apollo Guidance Computer";
            projects["Adele"] = "Graphical User Interfaces";


            // Step Four: Remove an item (this comment doesn't appear in the student starter)
            projects.Remove("Grace");


            // Step Three: Loop through a Dictionary
            foreach (KeyValuePair<string, string> project in projects)
            {
                Console.WriteLine("The key " + project.Key + " is linked to the value " + project.Value);
            }
        }
    }
}
