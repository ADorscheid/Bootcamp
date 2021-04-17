using System;

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
            numberOfExercises = 26;
            Console.WriteLine(numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half;
            half = .5;
            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name;
            name = "TechElevator";
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
            string myName = "Mike";
            Console.WriteLine(myName);

            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            int numberOfMouseButtons = 3;
            Console.WriteLine(numberOfMouseButtons);

            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            double percentageBatteryLeft = 79.5;
            Console.WriteLine(percentageBatteryLeft);

            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int difference = 121 - 27;
            Console.WriteLine(difference);
            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double sum = 12.3 + 32.1;
            Console.WriteLine(sum);

            /*
            12. Create a string that holds your full name.
            */
            myName = "Mike Morel";

            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string greeting = "Hello, " + myName;
            Console.WriteLine(greeting);

            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable. (I want "Hello, Mike Morel Esquire")
            */
            greeting = greeting + " Esquire";
            Console.WriteLine(greeting);

            int age = 25;
            age = age + 1;
            Console.WriteLine(age);


            /*
            15. Now do the same as exercise 14, but use the += operator.
            */
            greeting += " all around good guy";
            age += 1;

            Console.WriteLine(greeting + ", age " + age);

            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            string saw = "Saw";
            saw += 2;
            Console.WriteLine(saw);
            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */

            /*
            18. What is 4.4 divided by 2.2?
            */
            Console.WriteLine(4.4 / 2.2);

            /*
            19. What is 5.4 divided by 2?
            */
            Console.WriteLine(5.4 / 2);

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            Console.WriteLine(5 / 2);

            /*
            21. What is 5.0 divided by 2?
            */
            Console.WriteLine(5.0 / 2);

            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */
            decimal balance = 1234.56M;
            Console.WriteLine(balance);

            // A second way to get a double into a decimal
            decimal myBal = (decimal)1234.56;
            Console.WriteLine(myBal);
            /*
            23. If I divide 5 by 2, what's my remainder?
            */
            Console.WriteLine(5 % 2);
            Console.WriteLine(4 % 2);

            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together. 
                What is the result?
            */
            int multiplicand = 3;
            int multiplier = 1_000_000_000;
            long product = multiplicand * (long)multiplier;
            Console.WriteLine(product);

            /*
            25. Create a variable that holds a boolean called doneWithExercises and
            set it to false.
            */
            bool doneWithExercises = false;

            /*
            26. Now set doneWithExercise to true.
            */
            doneWithExercises = true;
            Console.WriteLine(doneWithExercises);

            // Stop and wait for the user to press Enter
            //Console.ReadLine();
        }
    }
}
