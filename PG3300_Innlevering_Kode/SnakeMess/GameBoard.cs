using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SnakeMess
{
    class GameBoard
    {

        public bool Paused {get; private set;}
        public bool GameOver {get; set;}

        public int Width {get; private set;}
        public int Height {get; private set;}
        private Snake _snake;
        List<Food> FoodList;
<<<<<<< HEAD
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
=======
        public GameBoard(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void StartGame()
        {
            _snake = new Snake(this);
            Paused = false;
            GameOver = false;

            while (!GameOver)
            {
                if (Console.KeyAvailable)
                {
                    var consoleKey = Console.ReadKey(true);
                    if (consoleKey.Key == ConsoleKey.Escape)
                    {
                        GameOver = true;
                        break;
                    }
                    else if (consoleKey.Key == ConsoleKey.Spacebar)
                    {
                        Paused = true;
                    }
                    if (Paused)
                    {
                        Thread.Sleep(300);
                        continue;
                    }
                    _snake.setDirection(consoleKey);
                }
                _snake.moveSnake();
                Thread.Sleep(100);
            }
        }
>>>>>>> 2bf947c6bd576ffddffe10014c154372753b3ba3
    }
}
