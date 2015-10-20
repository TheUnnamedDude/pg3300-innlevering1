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
        Random rng = new Random();

        public int Width {get; private set;}
        public int Height {get; private set;}
        private Snake _snake;
        List<Food> FoodList;
        Snake snake;
        bool pause, gameOver;

        public void spawnFood()
        {
            var test = FoodList.Count();
            while (test <= 0 )
            {
                Coordinate temp = new Coordinate(rng.Next(0, Width), rng.Next(0, Height));
                if (!snake.Body.Any(snakePart => (snakePart.X == temp.X && snakePart.Y == temp.Y))) ;
                {
                    FoodList.Add(new Food(temp));
                    FoodList.Last().Write();
                }
            }
        }
        public GameBoard(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void StartGame()
        {
            FoodList = new List<Food>();
            _snake = new Snake(this);
            Paused = false;
            GameOver = false;

            while (!GameOver)
            {
                
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                    if (consoleKey.Key == ConsoleKey.Escape)
                    {
                        GameOver = true;
                        break;
                    }
                    else if (consoleKey.Key == ConsoleKey.Spacebar)
                    {
                        Paused = !Paused;
                    }
                    if (Paused)
                    {
                        Thread.Sleep(300);
                        Paused = !Paused;
                        continue;
                    }
                    _snake.setDirection(consoleKey);
                }
                _snake.moveSnake();
                spawnFood();
                Thread.Sleep(100);
            }
        }
    }
}
