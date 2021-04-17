using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulator
{
    public class Car
    {
        /*************************************************************
         * Private fields (not properties)
         * **********************************************************/
        public int maxSpeed = 120;
        
        /*************************************************************
         * Automatic properties
         * Can be set or get at any time. 
         * ***********************************************************/
        // Automatic property to hold the color of the Car
        public string Color { get; set; }

  
        /*************************************************************
         * Derived properties
         * Only has a Get, and that value is calculated based on other properties 
         * ***********************************************************/
        // Create a derived property.  Age depends on (is derived from) the car's Year property.
        public int Age
        {
            get
            {
                int currentYear = DateTime.Now.Year;
                // Age is the current year minus the Year of the car
                return currentYear - Year;
            }
        }


        /*************************************************************
         * Get-private-set
         * Other classes can see (get) the value, but only the class itself can change (set) it. 
         * ***********************************************************/
        // Speed is publicly gettable, but not publicly settable (caller must call Accellerate to change speed). 
        // Initialized to 0.
        public int Speed { get; private set; } = 0;

        /*************************************************************
         * Backed properties
         * We create a private field to store a value, and a public property 
         * with Get/Set methods to control access to the value. 
         * ***********************************************************/
        // Backed property for Gear. We want control over what Gear the user
        // puts the car into. For example, we cannot let them put the car into
        // "X" gear, or change directly from "D" to "R"
        private string gear = "P";
        public string Gear
        {
            get
            {
                return this.gear;
            }
            set
            {
                if (value == "P" && Speed == 0)
                {
                    this.gear = "P";
                }
                else if (value == "D" && (gear == "P" || gear == "N"))
                {
                    this.gear = "D";
                }
                else if (value == "N")
                {
                    this.gear = "N";
                }
                else if (value == "R" && Speed == 0)
                {
                    this.gear = "R";
                }
            }
        }

        /**********************************************
         * TODO: Make these read-only!!!
         * Read-only properties
         * Certain properties should be set when the car is created, but not changed after that
         * *******************************************/
        // Vehicle ID.  If this changes after a car is constructed, that would be fraud
        public string VIN { get; set; }
        // Vehicle Make (Chevy). Never changes.
        public string Make { get; set; }
        // Vehicle Model (Corvette). Never changes
        public string Model { get; set; }
        // Year the car was built. Never changes.
        public int Year { get; }


        /***************************************************************************
         * Class Constructor
         * Constructors are a special method that runs at the time the instance is 
         * created (new'd).  If no constructor is defined, a "default" parameterless
         * contstructor is created for us automatically.
         * *************************************************************************/

        // This is a default constructor. We can remove this later if we don't want the user to be able to create 
        // a completely "blank" Car instance.
        public Car()
        {
            this.VIN = GenerateVIN();
        }

        // Create a constructor for Car that accepts a vin, year, make and model
        public Car(int year, string make, string model)
        {
            this.VIN = GenerateVIN();
            this.Year = year;
            this.Make = make;
            this.Model = model;
            this.gear = "P";
        }

        /****************************************************************************
         * Methods
         * *************************************************************************/
        // Accelerate allows the car to change speeds. We can change the speed from 
        // this method because Speed has a "private set".
        public void Accelerate()
        {
            if (this.Speed < maxSpeed)
            {
                this.Speed++;
            }
        }

        /****************************************************************************
         * Method overload
         * *************************************************************************/
        // We have a second Accelerate method (an overload) which allows the user to 
        // specify the amount of acceleration.
        public void Accelerate(int mph)
        {
            int targetSpeed = this.Speed + mph;
            if (targetSpeed >= 0 && targetSpeed <= maxSpeed)
            {
                this.Speed += mph;
            }
        }

        /****************************************************************************
        * Private Methods
        * These are methods that we can use internally, but the public can never call.
        * *************************************************************************/
        private string GenerateVIN()
        {
            Random randomNumberGenerator = new Random();
            int vin = randomNumberGenerator.Next(1_000_000, int.MaxValue);
            return vin.ToString("0000000000");
        }


    }
}
