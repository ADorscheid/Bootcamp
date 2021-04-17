using System;
using System.Collections.Generic;
using System.Text;

namespace LinqLambda.Models
{
    public class PersonTargetWeight
    {
        public string Name { get; set; }
        public int TargetWeightLow { get; set; }
        public int TargetWeightHigh { get; set; }

        public PersonTargetWeight(string name, int low, int high)
        {
            Name = name;
            TargetWeightLow = low;
            TargetWeightHigh = high;
        }
        public override string ToString()
        {
            return $"Target weight for {Name} is {TargetWeightLow} - {TargetWeightHigh} pounds.";
        }
    }
}
