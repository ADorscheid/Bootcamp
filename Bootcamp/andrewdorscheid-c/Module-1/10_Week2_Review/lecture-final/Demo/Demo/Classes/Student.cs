using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Classes
{
    public class Student
    {

        private int nonStaticField = 0;
        static private int countOfInstances = 0;

        public string Name { get; set; }
        public List<int> Scores { get; private set; } = new List<int>();

        public double AverageScore
        {
            get
            {
                if (Scores.Count == 0)
                {
                    return 0.0;
                }
                double sum = 0;
                foreach (int score in Scores)
                {
                    sum += score;
                }
                return sum / Scores.Count;
            }
        }


        public string SSN { private get; set; }



        public Student(string name, string ssn)
        {
            Name = name;
            SSN = ssn;

            Student.countOfInstances++;
            this.nonStaticField++;
        }

        public void AddScore(int score)
        {
            this.Scores.Add(score);
        }

        public static int GetCurve()
        {
            return 14;
        }
    }
}
