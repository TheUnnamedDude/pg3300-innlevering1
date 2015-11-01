using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class GameController
    {
        public static void Main(string[] args)
        {
            // Store the original console state so we can restore it after the game is over
            var originalTitle = Console.Title;
            var originalColor = Console.ForegroundColor;
            var originalCursorVisible = Console.CursorVisible;

            // I pressed ctrl + c to stop the game too many times...
            Console.CancelKeyPress += delegate
            {
                Console.Title = originalTitle;
                Console.CursorVisible = originalCursorVisible;
                Console.ForegroundColor = originalColor;
                Console.Clear();
            };

            // Prepare the console
            Console.Clear(); // Lets clear the console window
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Create a gameboard and start the game
            var gameBoard = new SnakeBoard(Console.WindowWidth, Console.WindowHeight, RenderingFactory.createRenderer());
            gameBoard.startGame();

            // Set the cursor visible back to the original value to leave the console in a usable state...
            Console.ResetColor();
            Console.Title = originalTitle;
            Console.ForegroundColor = originalColor;
            Console.CursorVisible = originalCursorVisible;
            Console.Clear();
        }
    }
}
