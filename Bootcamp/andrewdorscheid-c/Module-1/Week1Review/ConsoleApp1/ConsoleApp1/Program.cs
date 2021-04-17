using System;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args)
        {
            //1=initialize the variable (i)
            //2=comparison for when to stop (i<=10)
            //3=increment  (i++)

            loopy();
            loopy2();

        }//end of main
        static void loopy2()
        {
        // every number from -5 to 5
        for (int i = -5; i <= 5; i++)
        {
                Console.WriteLine(i);
        }
        }
        static void loopy()
        {
            for (int i = 0; i <= 10; i = i + 3)
            {
                Console.WriteLine(i);
            }

            for (int i = 2; i <= 9; i++)
            {
                Console.WriteLine(i);
            }





        }


        static void makePBJ() {
            /*PBJ
             *   get out the bread
             *   GetOutTheJelly  
             *   get out the PB
             *   open the bread
             *   put jelly on the bread
             *   
             *   
             *   **** GetOutTheJelly
             *   go to the fridge. open the fridge. look on the top shelf. grab the jelly
             */
        }

        static void sayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
