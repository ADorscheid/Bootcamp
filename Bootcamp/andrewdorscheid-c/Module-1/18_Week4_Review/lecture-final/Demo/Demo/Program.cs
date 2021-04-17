using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<State> states = new List<State>()
            {
                new State("AL", "Alabama"),
                new State("DE", "Deleware"),
                new State("ND", "North Dakota")
            };

            while (true)
            {
                Console.Write("Enter Code: ");
                string input = Console.ReadLine();

                if (input.Length == 0)
                {
                    break;
                }

                // Lookup the state by code
                State result = null;
                foreach(State s in states)
                {
                    if (s.Code.ToLower() == input.ToLower())
                    {
                        result = s;
                        break;
                    }
                }

                // At this point, State is either null (not found, or contains a state (found)
                if (result == null)
                {
                    Console.WriteLine("Not found");

                }
                else
                {
                    Console.WriteLine($"State is {result.Name}");
                }


            }

        }
    }
}
