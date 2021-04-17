using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lecture.Aids
{
    public class FileAndDirDemo
    {
        public void DoFileAndDirDemo()
        {
            // Print out the current working directory
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);

            // List the folders in the folder that holds the solution file (up 3)
            path = "..\\..\\..";

            string[] dirs = Directory.GetDirectories(path);
            Console.WriteLine("*** *** *** *** *** ***");
            foreach (string dir in dirs)
            {
                Console.WriteLine($"\t{dir}");
            }

            // List the files in that folder
            string[] files = Directory.GetFiles(path);
            Console.WriteLine("*** *** *** *** *** ***");
            foreach (string file in files)
            {
                Console.WriteLine($"\t{file}");
            }

            // Get a DirectoryInfo object for the Files folder

            // Use the Path object to append the Files folder
            path = Path.Combine(path, "Files");
            files = Directory.GetFiles(path);

            // List the files in that directory
            Console.WriteLine("*** *** *** *** *** ***");
            foreach (string file in files)
            {
                Console.WriteLine($"\t{file}");
            }

            // Get a FileInfo for the Declaration.txt file
            path = Path.Combine(path, "Declaration.txt");
            FileInfo fi = new FileInfo(path);

            Console.WriteLine("*** *** *** *** *** ***");
            // Display file information
            Console.WriteLine($"File: {fi.FullName}, Size: {fi.Length} bytes, Created: {fi.CreationTime}");

            // Read the file
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    Console.WriteLine(s);
                }
            }

        }
    }
}
