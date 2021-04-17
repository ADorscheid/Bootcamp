using System;
using System.Drawing;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            TShirt myShirt;              //Declare
            myShirt = new TShirt();      //Allocate/Instantiate
            myShirt.size = 16.3f; //Initialize


        }
    }

    class TShirt {
        public float size;
        public string fabric;
        public string slogan;
        public Color color;
        public void shrink() { }
        public void dye(Color colorToDye) { }
    }


    class Car {
        public string make;
        public string model;
        public string year;
        public int gallonsOfGas;
        public string vin;

        public void addGas(int gallonsToAdd) { }
        public void drive() { }
    }

        
    }
}
