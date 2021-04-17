using Lecture.Aids;
using System;
using System.IO;

namespace FileAndDirectory
{
    class Program
    {
        static void Main(string[] args)
        {

            //Directory.Delete(@"C:\TestDirectory");



            //// Files and Directories
            //FileAndDirectories fad = new FileAndDirectories();
            //fad.UsingTheDirectoryClass();
            //fad.UsingTheFileClass();

            // File Paths
            //FilePaths fp = new FilePaths();
            //fp.UsingPathToCombineTwoFilePaths();
            //fp.GettingExtensions();
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

            string s = @"C:\Temp\my.File.txt";


            string ext = s.Substring(s.LastIndexOf(".") + 1);
            string[] parts = s.Split(".");
            string ext2 = parts[parts.Length - 1];

            string ext3 = Path.GetExtension(s);


            // Read and display an entire text file
            string path = @"..\..\..\Files\Declaration.txt";
            using (StreamReader rdr = new StreamReader(path))
            {
                string body = rdr.ReadToEnd();
                Console.WriteLine(body);
            }

            Console.Clear();

            // Read and display a file line-by-line, with line numbers
            path = @"..\..\..\Files\Hamlet.txt";
            using (StreamReader rdr = new StreamReader(path))
            {
                int lineNumber = 1;
                while (!rdr.EndOfStream)
                {
                    string line = rdr.ReadLine();
                    Console.WriteLine($"{lineNumber} {line}");
                    lineNumber++;
                }
            }




            Console.Write("Now, wasn't that FUN???");
            return;
        }

    }
}
