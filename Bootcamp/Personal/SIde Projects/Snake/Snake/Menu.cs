using System;
using System.Collections.Generic;
using System.Text;
using MenuFramework;

namespace Snake
{
    public class Menu : ConsoleMenu
    {
        
        public Menu()
        {
            AddOption("Play Game", PlayGame);
            AddOption("View High Scores", ViewHighScores);
            AddOption("Exit", Exit);
        }

        private MenuOptionResult PlayGame()
        {
            Console.WriteLine("Enter the size of one side of the board (if 10 is entered, board 10x10 will be made): ");

            // gameSize makes a gameSize x gameSize board for the snake (resizes the border)
            int gameSize = int.Parse(Console.ReadLine());
            
            // gameSize generates the X and Y coordinates of fruit at random between 0 and gameSize
            Fruit fruit = new Fruit(gameSize);
            
            // makes the game border based on gameSize variable (gameSize x gameSize board), and places the fruit into the board
            GameBorder gameBorder = new GameBorder(gameSize, fruit);

            // create the snake
            Snake snake = new Snake();

            // need to press enter for the snake to move
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ViewHighScores()
        {
            // need to press enter to return to the menu
            Scoreboard.ViewScores();
            Console.WriteLine("\nPress enter to return to main menu");
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
