using Lecture.Aids;
using System;
using System.IO;

namespace FileAndDirectory
{
    class Program
    {
        static void Main(string[] args)
        {

            // Files and Directories
            //FileAndDirectories fad = new FileAndDirectories();
            //fad.UsingTheDirectoryClass();
            //fad.UsingTheFileClass();

            // File Paths
            //FilePaths fp = new FilePaths();
            //fp.UsingPathToCombineTwoFilePaths();
            //fp.UsingPathForTemporaryFolders();

            // Reading Text Files
            //ReadingTextFiles rtf = new ReadingTextFiles();
            //rtf.ReadACharacterFile();

            // Reading CSV
            //ReadingCSVFiles rcf = new ReadingCSVFiles();
            //rcf.ReadFile();

            // Summing up numbers
            //SummingUpNumbers sun = new SummingUpNumbers();
            //sun.ReadFile();

            // Navigator
            //Navigator nav = new Navigator();
            //nav.Run();

            // File 
            //FileAndDirDemo fdDemo = new FileAndDirDemo();
            //fdDemo.DoFileAndDirDemo();
            //Console.ReadLine();

            // Path
            //PathDemo pd = new PathDemo();
            //pd.DoPathDemo();


            //use ReadToEnd
            string path = @"../../../Files/Declaration.txt";
            using (StreamReader rdr = new StreamReader(path)) {
                string body = rdr.ReadToEnd();
                Console.WriteLine("\n\n\n" + body + "\n\n\n");
            }

            //Read a file line by line
            Console.WriteLine("\n\n\n\n\n");
            path = @"..\..\..\Files\Hamlet.txt";
            using (StreamReader rdr = new StreamReader(path))
            {
                string line = "";
                int lineNumber = 1;
                while (!rdr.EndOfStream)
                {
                    line = rdr.ReadLine();
                    Console.WriteLine($"{lineNumber} {line}");
                    lineNumber++;
                }
            }


                Console.Write("Now, wasn't that FUN???");
            return;
        }

    }
}
