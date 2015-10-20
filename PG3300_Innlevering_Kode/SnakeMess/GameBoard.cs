using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class GameBoard
    {
        int height, width;
        List<Food> FoodList;
        Snake snake;
        bool pause, gameOver;

        public bool deathCheck()
        {
            return boundCheck() || snake.collisionCheck(snake.HeadPosition);

        }
        public bool boundCheck()
        {
            if (snake.HeadPosition.X >= width || snake.HeadPosition.X <= 0 || snake.HeadPosition.Y >= height || snake.HeadPosition.Y <= 0)
            {
                return true;
            }
            return false;
        }
        public void keyListener()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                    gameOver = true;
                else if (cki.Key == ConsoleKey.Spacebar)
                    pause = !pause;
            } else
            {
                snake.moveSnake();
            }
        }
        public void spawnFood()
        {
           
        }
    }
}
