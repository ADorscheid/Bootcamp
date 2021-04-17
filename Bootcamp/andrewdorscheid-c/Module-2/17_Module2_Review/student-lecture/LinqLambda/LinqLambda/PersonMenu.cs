using LinqLambda.Models;
using MenuFramework;
using System;
using System.Collections.Generic;

namespace LinqLambda
{
    public class PersonMenu : ConsoleMenu
    {
        private List<Person> People = new List<Person>()
        {
            new Person("Bobby", 27, 71),
            new Person("Tyler", 27, 72),
            new Person("El", 26, 60),
            new Person("Jesse", 29, 78),
            new Person("Chris", 29, 74),
            new Person("Sirrena", 24, 71),
            new Person("John S", 42, 70),
            new Person("Jacob", 23, 70),
        };

        public PersonMenu()
        {
            AddOption("Display List Raw", () =>
            {
                PrintList(People);
                return MenuOptionResult.WaitAfterMenuSelection;
            })
                .AddOption("Sort by Name", SortByName)
                .AddOption("Sort by Age DESC", SortByAge)
                .AddOption("Map Person to Target Weight", MapToTargetWeight)
                .AddOption("Filter by Height", FilterByHeight)
                .AddOption("Get a Count of tall people", CountByHeight)
                .AddOption("Get the sum of all Heights", SumHeights)
                .AddOption("Get the product of all ages", MultiplyAges)
                .AddOption("Get a concatenation of all names", JoinNames)
                .AddOption("Exit", Exit);
        }

        private MenuOptionResult SortByName()
        {
            Console.WriteLine("NOT YET IMPLEMENTED!!");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult SortByAge()
        {
            Console.WriteLine("NOT YET IMPLEMENTED!!");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult MapToTargetWeight()
        {
            // TODO: Replace this with a call to Select
            List<PersonTargetWeight> list = new List<PersonTargetWeight>();
            foreach (Person p in People)
            {
                PersonTargetWeight ptw = new PersonTargetWeight(p.Name, GetWeightForHeightAndBMI(p.Height, 18.5), GetWeightForHeightAndBMI(p.Height, 25));
                list.Add(ptw);
            }
            PrintList(list);
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult FilterByHeight()
        {
            int minHeight = GetInteger("\tTaller than (how many inches)? ");

            // TODO: Replace this with a call to Where

            // Filter by height
            List<Person> list = new List<Person>();
            foreach (Person p in People)
            {
                if (p.Height > minHeight)
                {
                    list.Add(p);
                }
            }
            PrintList(list);
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult CountByHeight()
        {
            int minHeight = GetInteger("\tTaller than (how many inches)? ");

            // TODO: Replace this with a call to Count

            // Get a count of people taller than minHeight
            int count = 0;
            foreach (Person p in People)
            {
                if (p.Height > minHeight)
                {
                    count++;
                }
            }
            Console.WriteLine($"There are {count} people taller than {minHeight} inches.");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult SumHeights()
        {
            // TODO: Replace this with a call to Sum

            // Get the length of people end-to-end
            int sum = 0;
            foreach (Person p in People)
            {
                sum += p.Height;
            }
            Console.WriteLine($"Total Height is {sum}");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult MultiplyAges()
        {
            // Get the product of people's ages
            // TODO: Replace this with a call to Aggregate

            long product = 1;
            foreach (Person p in People)
            {
                product *= p.Age;
            }
            Console.WriteLine($"Product of ages is {product}");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult JoinNames()
        {
            Console.WriteLine("NOT YET IMPLEMENTED!!");
            //string longName = People.Aggregate("", (accum, p) => { return accum + ((accum.Length == 0) ? "" : "_") + p.Name; });
            //Console.WriteLine($"Names aggregated: {longName}");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        #region Utility Functions
        /// <summary>
        /// Utility to loop through a list and print it
        /// </summary>
        /// <param name="list"></param>
        private void PrintList(IEnumerable<Object> list)
        {
            Console.WriteLine();
            Console.WriteLine(Person.Heading());
            foreach (Object obj in list)
            {
                Console.WriteLine(obj);
            }
        }

        private int GetWeightForHeightAndBMI(int heightInches, double targetBMI)
        {
            return (int)(Math.Round((targetBMI * heightInches * heightInches) / 703.0));
        }
        #endregion

    }
}
