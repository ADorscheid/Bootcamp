using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
        Given two lists of Integers, interleave them beginning with the first element in the first list followed
        by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
        Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
        list to the new list before returning it.
        DIFFICULTY: HARD
        InterleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
        */
        public List<int> InterleaveLists(List<int> listOne, List<int> listTwo)
        {
            List<int> finalList = new List<int>();

            if (listOne.Count > listTwo.Count) {
                //add from both lists up to the end of list two, because it is smaller
                for (int i=0;i<listTwo.Count;i++) {
                    finalList.Add(listOne[i]);
                    finalList.Add(listTwo[i]);
                }
                //add the rest of the items from list 1
                for (int i=listTwo.Count;i<listOne.Count;i++) {
                    finalList.Add(listOne[i]);
                }
            } else {
                //list two is greater OR they are equal
                for (int i=0;i<listOne.Count;i++) {
                    finalList.Add(listOne[i]);
                    finalList.Add(listTwo[i]);
                }

                //add the rest of the items from list 2 (if equal, the loop wont run)
                for (int i = listOne.Count;i<listTwo.Count;i++) {
                    finalList.Add(listTwo[i]);
                }
            }

            return finalList;
        }
    }
}
