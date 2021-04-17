using System;
using Lecture.Aids;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Here are a few examples of reading in a file and writing out values
            // to demonstrate their value.
            //WritingTextFiles.WritingAFile();
            //BinaryFileWriter.WritePrimitiveValues();          
            BinaryImageManipulator.FunWithPhoto();
            //PerformanceDemo.SlowPerformance();
            //PerformanceDemo.FastPerformance();


            Console.Write("Press enter to finish");
            Console.ReadLine();
        }
    }
}
