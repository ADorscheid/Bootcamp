using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lecture.Aids
{
    public class PathDemo
    {
        public void DoPathDemo()
        {
            string path1 = @"c:\temp\MyTest.txt";
            string path2 = @"c:\temp\MyTest";
            string path3 = @"temp";

            ShowPathInfo(path1);
            ShowPathInfo(path2);
            ShowPathInfo(path3);


            // Get the temp path, get a temp file name, get a random file name...
            Console.WriteLine($"{Path.GetTempPath()} is the location for temporary files.");
            Console.WriteLine($"{Path.GetTempFileName()} is a file available for use.");
            Console.WriteLine($"{Path.GetRandomFileName()} is a random file name.");


            /* This code produces output similar to the following:
             * c:\temp\MyTest.txt has an extension.
             * c:\temp\MyTest has no extension.
             * The string temp contains no root information.
             * The full path of temp is D:\Documents and Settings\cliffc\My Documents\Visual Studio 2005\Projects\ConsoleApplication2\ConsoleApplication2\bin\Debug\temp.
             * D:\Documents and Settings\cliffc\Local Settings\Temp\8\ is the location for temporary files.
             * D:\Documents and Settings\cliffc\Local Settings\Temp\8\tmp3D.tmp is a file available for use.
             */
        }

        public void ShowPathInfo(string path)
        {
            // Does this path have an extension?
            if (Path.HasExtension(path))
            {
                Console.WriteLine($"{path} has an extension.");
                Console.WriteLine($"Extension is {Path.GetExtension(path)}");
            }
            else
            {
                Console.WriteLine($"{path} has no extension.");
            }

            // Is this path rooted?
            Console.WriteLine($"{path} has a root: {Path.IsPathRooted(path)}");

            // Get the current working directory so we can call GetRelativePath
            string currentPath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Your current path is {currentPath}");

            // Show the absolute and relative path for the path given
            Console.WriteLine($"Absolute Path: {Path.GetFullPath(path)}");
            Console.WriteLine($"Relative Path: {Path.GetRelativePath( currentPath, path)}");
            Console.WriteLine("*********************************");

        }

    }
}
