using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class GameController
    {

        bool originalCursorVisible = Console.CursorVisible;

        public String Title { get; set; }
        public GameBoard Gametable {
            get
            {
                return Gametable;
            }
            set
            {
                new GameBoard(Console.WindowWidth, Console.WindowHeight);
            }
        }

        
        public static void Main(string[] args)
        {
			bool originalCursorVisible = Console.CursorVisible; // Save the state
			Console.Clear(); // Lets clear the console window
            Console.CursorVisible = false;
        	Console.Title = "Westerdals Oslo ACT - SNAKE";
        	Console.ForegroundColor = ConsoleColor.Yellow;
            var gameBoard = new GameBoard(Console.WindowWidth, Console.WindowHeight);
            gameBoard.startGame();
            Console.ResetColor();
			// Set the cursor visible back to the original value to leave the console in a usable state...
			Console.CursorVisible = originalCursorVisible;
			Console.Clear();
        }
    }
}
