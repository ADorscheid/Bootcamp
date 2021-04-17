using Demo.Classes;
using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> csharpClass = new List<Student>();

            Student.GetCurve();



            Console.WriteLine();


            Student person = new Student("Todd", "123456789");
            person.AddScore(3);
            person.AddScore(3);
            person.AddScore(2);
            person.AddScore(3);

            Console.WriteLine($"{person.Name}'s average score is {person.AverageScore}");


            Student s2 = new Student("s2", "111");
            Student s3 = new Student("s3", "111");
        }
    }
}
