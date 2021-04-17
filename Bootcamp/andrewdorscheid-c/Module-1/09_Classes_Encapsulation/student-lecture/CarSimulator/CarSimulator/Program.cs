using System;
using System.Collections.Generic;

namespace CarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Car using the default constructor.  Can I see any private members?
            // TODO: Later, use a "better" constructor
            List<string> myList = new List<string>();
            Car mikesCar = new Car();
            mikesCar.Color = "Blue";   //use the setter
            Console.WriteLine($"Mike's car is {mikesCar.Color} and it is {mikesCar.Age} years old");

            // Set the cars properties: Make, model, year. Try to set its Age.
            
            mikesCar.Make = "Toyota";
            mikesCar.Model = "Corolla";


            // Create a new Car object (Create a new object of type Car) using a different constructor
            Car bensCar = new Car(2021, "Jeep", "Wrangler");

            // Display the car property values, including Age


            // Try to put the car into gear
            mikesCar.Gear = "R";  //the setter code is being executed
            Console.WriteLine($"Mike's car is in {mikesCar.Gear}");

            mikesCar.Gear = "D";
            Console.WriteLine($"Now Mike's car is in {mikesCar.Gear}");


            // Speed up to 60mph
            while (mikesCar.Speed < 60) {
                mikesCar.Accelerate();
                Console.WriteLine($"Mike's car is now traveling at {mikesCar.Speed}");
            }

            // When the car hits 20mph, try to put it into Reverse


            // Now let's brake hard. (Call the overloaded Accellerate)
            while (mikesCar.Speed > 0) {
                mikesCar.Accelerate(-5);
            }
            Console.WriteLine($"Mike's car is now driving at {mikesCar.Speed} mph");
        }
    }
}
