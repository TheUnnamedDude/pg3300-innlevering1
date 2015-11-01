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
			bool originalCursorVisible = Console.CursorVisible; // Save the state
            string originalTitle = Console.Title;
            ConsoleColor originalColor = Console.ForegroundColor;

            // I pressed ctrl + c to stop the game too many times...
            Console.CancelKeyPress += delegate
            {
                Console.Title = originalTitle;
			    Console.CursorVisible = originalCursorVisible;
                Console.ForegroundColor = originalColor;
			    Console.Clear();
            };
            
			Console.Clear(); // Lets clear the console window
            Console.CursorVisible = false;
        	Console.Title = "Westerdals Oslo ACT - SNAKE";
        	Console.ForegroundColor = ConsoleColor.Yellow;
            var gameBoard = new SnakeBoard(Console.WindowWidth, Console.WindowHeight, RenderingFactory.createRenderer());
            gameBoard.startGame();
            Console.ResetColor();
			// Set the cursor visible back to the original value to leave the console in a usable state...
            Console.Title = originalTitle;
			Console.CursorVisible = originalCursorVisible;
            Console.ForegroundColor = originalColor;
			Console.Clear();
        }
    }
}
