using System;

namespace CarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Car using the default constructor.  Can I see any private members?
            // TODO: Later, use a "better" constructor

            Car mikesCar = new Car(2015, "Toyota", "Corolla");

            // Set the cars properties: Make, model, year. Try to set its Age.
            mikesCar.Color = "Beige";
            //mikesCar.Year = 2015;
            //mikesCar.Make = "Toyota";
            //mikesCar.Model = "Corolla";

            // I cannot do this!  There is no "set" on the property
            //mikesCar.Age = 2;

            Console.WriteLine($"Mike's car is {mikesCar.Color} and it is {mikesCar.Age} years old.");


            // Create a new Car object (Create a new object of type Car)


            // Display the car property values, including Age


            // Try to put the car into gear
            mikesCar.Gear = "R";
            Console.WriteLine($"mike's car is now in {mikesCar.Gear} gear");

            mikesCar.Gear = "D";
            Console.WriteLine($"mike's car is now in {mikesCar.Gear} gear");




            // Speed up to 60mph
            while (mikesCar.Speed < 60)
            {
                mikesCar.Accelerate();
            // When the car hits 20mph, try to put it into Reverse
                Console.WriteLine($"Your speed is now {mikesCar.Speed}.");
            }



            // Now let's brake hard. (Call the overloaded Accellerate)
            while (mikesCar.Speed > 0)
            {
                mikesCar.Accelerate(-5);
                Console.WriteLine($"Your speed is now {mikesCar.Speed}.");
            }
        }
    }
}
