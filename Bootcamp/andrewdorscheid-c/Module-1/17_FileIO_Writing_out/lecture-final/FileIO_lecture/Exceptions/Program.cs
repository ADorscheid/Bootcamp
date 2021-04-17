using Exceptions.Classes;
using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DoSomethingDangerous
            /* 
            * try/catch blocks will also catch Exceptions that are 
            * thrown from method called further down the stack 
            */
            Console.WriteLine("About to call");
            try
            {
                int result = DoSomethingDangerous();
                Console.WriteLine($"Called and the result is {result}.");
            }
            catch (Exception)
            {
                Console.WriteLine("BAD news!");
            }
            finally
            {
                Console.WriteLine("I'm in the 'finally' block inside Main.");
            }


            #endregion

            #region DoMathFun
            //DoMathFun();
            //Console.ReadLine();
            #endregion

            #region A template for error-handling...
            try
            {
                // Do some work here...
            }
            catch (ArgumentNullException e)
            {
                // catch most specific Exceptions first
            }
            catch (Exception e)
            {
                // (optional) catch more general exceptions later
                // (optional) re-throw the same exception so it can be caught further up the stack
                throw;
            }
            finally
            {
                // (optional) Do work that should execute whether the above succeeded or failed
            }
            #endregion

        }

        private static int DoSomethingDangerous()
        {
            try
            {
                int i1 = GetInteger("First Integer: ");

                int i2 = GetInteger("Second Integer: ");


                int answer = i1 / i2;
                Console.WriteLine($"The answer is {answer}.");
                return answer;
            }
            catch (DivideByZeroException ex)
            {
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong! {ex.Message}");
                throw;
            }
            finally
            {
                Console.WriteLine("I'm in the 'finally' block inside DoSomethingDangerous.");
            }

        }

        private static int GetInteger(string prompt)
        {
            int result = 0;
            bool gotNumber = false;
            while (!gotNumber)
            {
                try
                {
                    Console.Write(prompt);
                    result = int.Parse(Console.ReadLine());
                    gotNumber = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Bad data...");
                }
            }

            return result;
        }

        private static void DoMathFun()
        {
            try
            {
                MathFun math = new MathFun();
                Console.WriteLine(math.Average(new int[] { }));
                Console.WriteLine(math.ParseAndAdd("23, 45, 65"));
            }
            catch (Exception exc)
            {
                Console.WriteLine($"ERROR!!! {exc.Message}");
            }
            finally
            {
                Console.WriteLine("Running the final block...");
            }
        }

    }
}
