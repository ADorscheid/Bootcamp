using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {

        /*
        12. Now write the above using the Ternary operator ?:
        */
        public string ReturnFizzIfThreeUsingTernary(int number)
        {
            // Ternary: bool-expression ? value-if-true : value-if-false;
            return (number == 3) ? "Fizz" : "";
        }
    }
}
