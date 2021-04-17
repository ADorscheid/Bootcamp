using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.Classes
{
    class MathFun
    {
        public decimal Average(int[] nums)
        {
            decimal result = 0;
            foreach(int num in nums)
            {
                result += num;
            }
            return result / nums.Length;
        }

        public int ParseAndAdd(string commaSeparatedInts)
        {
            int result = 0;
            string[] strings = commaSeparatedInts.Split(",");
            foreach (string s in strings)
            {
                int i = int.Parse(s);
                result += i;
            }
            return result;
        }

        public double Divide(int a, int b)
        {
            return (double)a / b;
        }

    }
}
