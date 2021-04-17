using System;
using System.Diagnostics;

namespace Variables_And_Datatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */

            /*
		    1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.
		    */
            int numberOfExercises;
            numberOfExercises = 1;
            Console.WriteLine(numberOfExercises);
            
            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half = .5;
            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name = "TechElevator";
            Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            int seasonsOfFirefly = 1;
            Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage = "C#";
            Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */
            double pi = 3.1416;
            Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */
            string myName = "Ben";

            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            int numberOfMouseButtons = 3;

            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            int batteryLife = 3;


            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int diff10 = 121 - 27;
            Console.WriteLine(diff10);

            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double addition11 = 12.3 + 32.1;
            Console.WriteLine(addition11);
            

            /*
            12. Create a string that holds your full name.
            */
            string myFullName = "Ben Kennedy";
            Console.WriteLine(myFullName);
            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string greeting = "Hello, " + myName;
            Console.WriteLine(greeting);

            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            greeting = greeting + " Esquire";
            Console.WriteLine(greeting);


            /*
            15. Now do the same as exercise 14, but use the += operator.
            */
            greeting += " Esquire";

            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            string movie = "Saw" + 2;
            Console.WriteLine(movie);
            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */

            /*
            18. What is 4.4 divided by 2.2?
            */

            /*
            19. What is 5.4 divided by 2?
            */

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */

            /*
            21. What is 5.0 divided by 2?
            */

            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */

            /*
            23. If I divide 5 by 2, what's my remainder?
            */

            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together. 
                What is the result?
            */

            /*
            25. Create a variable that holds a boolean called doneWithExercises and
            set it to false.
            */

            /*
            26. Now set doneWithExercise to true.
            */


            Console.ReadLine();
        }
    }
}
