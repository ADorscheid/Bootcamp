using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use our custom Person data type (class)
            Person p = CreatePerson();
            Console.WriteLine(p.FirstName);


            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e
            char firstChar = name[0];
            char lastChar = name[name.Length - 1];
            Console.WriteLine($"First and Last Character: {firstChar}-{lastChar} ");

            // 2. How do we write code that prints out the first three characters
            // Output: Ada
            string first3OfName = name.Substring(0, 3);
            Console.WriteLine($"First 3 characters: {first3OfName}");

            // 3. Now print out the first three and the last three characters
            // Output: Adaace
            Console.WriteLine($"Last 3 characters: {name.Substring(0,3)}-{name.Substring(name.Length-3,3)}");

            // 4. What about the last word?
            // Output: Lovelace
            string[] peicesOfName = name.Split(" ");
            Console.WriteLine($"Last Word: {peicesOfName[peicesOfName.Length-1]}");

            // 5. Does the string contain inside of it "Love"?
            // Output: true
            string[] words = name.Split(" ");
            Console.WriteLine("Contains \"Love\"");

            // 6. Where does the string "lace" show up in name?
            // Output: 8
            int indexOfLace = name.IndexOf("lace");
            Console.WriteLine($"Index of \"lace\": {indexOfLace}");

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            int countOfA = 0;
            for (int i=0;i<name.Length;i++) {
                if (name.Substring(i,1).ToLower() == "a") {
                    countOfA++;
                }
            }
            Console.WriteLine($"Number of \"a's\": {countOfA}");

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"
            name = name.Replace("Ada", "Ada, Countess of Lovelace");
            Console.WriteLine(name);

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("All Done");
            }


        }

        public static Person CreatePerson()
        {
            Person instructor;
            instructor = new Person();
            instructor.FirstName = "Ben";
            return instructor;
        }
    }

}