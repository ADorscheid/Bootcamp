using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Snake
{
    public class Scoreboard
    {
        public static int HighScore { get; private set; }
        private static string Path = @"..\..\..\..\Scores.txt";

        public Scoreboard()
        {
            
        }

        public static void ViewScores()
        {
            // read the file and print off the top 10 high scores
            using (StreamReader sr = new StreamReader(Path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }

        public static void UpdateScores()
        {
            // update the file here
        }
    }
}
