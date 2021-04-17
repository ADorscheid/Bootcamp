using System;
using System.Collections.Generic;
using System.Text;

namespace LinqLambda.Models
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }

        public Person(string name, int age, int height)
        {
            this.Name = name;
            this.Age = age;
            this.Height = height;
        }

        public static string Heading()
        {
            return $"{"Name",-15}{"Age",4} {"Height",-9}\r\n{"--------------",-15}{"---",4} {"---------",-9}";
        }

        public override string ToString()
        {
            return $"{Name, -15}{Age, 4}{Height, 3} inches";
        }
    }

}
