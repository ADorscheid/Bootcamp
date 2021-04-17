using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lecture.Aids
{
    class Navigator
    {
        public void Run()
        {
            while (true)
            {
                string currentPath = Directory.GetCurrentDirectory();
                Console.Clear();

                Console.WriteLine("Windows Navigator");
                Console.WriteLine("-----------------");
                Console.WriteLine($"Current Directory: {currentPath}");
                Console.WriteLine();
                Console.WriteLine("1 - Navigate Directories");
                Console.WriteLine("2 - List Files");
                Console.WriteLine("3 - Read a file");
                Console.WriteLine("Q - Quit Navigator");

                switch (Console.ReadLine().Trim().ToLower())
                {
                    case "q":
                        return;
                    case "1":
                        NavigateDirectories();
                        break;
                    case "2":
                        ListFiles();
                        break;
                    case "3":
                        ReadFile();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void NavigateDirectories()
        {
            while (true)
            {
                Console.Clear();
                string currentPath = Directory.GetCurrentDirectory();
                string root = Directory.GetDirectoryRoot(currentPath);
                bool hasParent = (currentPath != root);
                Console.WriteLine("Navigate Directories Submenu");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Current Directory: {currentPath}");
                Console.WriteLine();
                string[] dirs = Directory.GetDirectories(currentPath);
                if (hasParent)
                {
                    Console.WriteLine("0 - UP to Parent");
                }
                for (int i = 0; i < dirs.Length; i++)
                {
                    string relativePath = Path.GetRelativePath(currentPath, dirs[i]);
                    Console.WriteLine($"{i + 1} - {relativePath}");

                }
                Console.WriteLine("Q - Back to Navigator menu");

                string input = Console.ReadLine().Trim().ToLower();
                if (input == "q")
                {
                    break;
                }
                else if (input == "0" && hasParent)
                {
                    string newPath = Path.Combine(currentPath, "..");
                    Directory.SetCurrentDirectory(newPath);
                }
                else
                {
                    int selection = 0;
                    if (int.TryParse(input, out selection) && selection > 0 && selection <= dirs.Length)
                    {
                        Directory.SetCurrentDirectory(dirs[selection - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                        Console.ReadLine();
                    }
                }
            }
        }

        private void ListFiles()
        {
            Console.Clear();
            string currentPath = Directory.GetCurrentDirectory();
            Console.WriteLine("List Files Submenu");
            Console.WriteLine("------------------");
            Console.WriteLine($"Current Directory: {currentPath}");
            Console.WriteLine();

            string[] files = Directory.GetFiles(currentPath);
            for (int i = 0; i < files.Length; i++)
            {
                string relativePath = Path.GetRelativePath(currentPath, files[i]);
                
                Console.WriteLine(relativePath);
            }
            Console.WriteLine();
            Console.WriteLine("Press RETURN to continue");
            Console.ReadLine();
        }

        private void ReadFile()
        {
            // List the files in the current dir and allow the user to select one.
            while (true)
            {
                Console.Clear();
                string currentPath = Directory.GetCurrentDirectory();
                Console.WriteLine("Read a File Submenu");
                Console.WriteLine("-------------------");
                Console.WriteLine($"Current Directory: {currentPath}");
                Console.WriteLine();

                string[] files = Directory.GetFiles(currentPath);
                for (int i = 0; i < files.Length; i++)
                {
                    string relativePath = Path.GetRelativePath(currentPath, files[i]);

                    Console.WriteLine($"{i + 1} - {relativePath}");
                }
                Console.WriteLine();
                Console.Write("Select a file to Read (Q to Quit): ");

                string input = Console.ReadLine().Trim().ToLower();
                if (input == "q")
                {
                    break;
                }
                else
                {
                    int selection = 0;
                    if (int.TryParse(input, out selection) && selection > 0 && selection <= files.Length)
                    {
                        ReadFile(files[selection - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                        Console.ReadLine();
                    }
                }
            }
        }

        private void ReadFile(string path)
        {
            // Open and read each line from the file
            // Read the file in line-by-line, and number each line on the screen
            using (StreamReader stream = new StreamReader(path))
            {
                // Read a line at a time.
                int lineNumber = 1;
                ConsoleColor standardFore = Console.ForegroundColor;
                ConsoleColor standardBack = Console.BackgroundColor;
                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write($"{lineNumber:000} ");
                    Console.ForegroundColor = standardFore;
                    Console.BackgroundColor = standardBack;
                    Console.WriteLine(line);
                    lineNumber++;
                }
            }

            Console.ReadLine();
        }
    }
}
