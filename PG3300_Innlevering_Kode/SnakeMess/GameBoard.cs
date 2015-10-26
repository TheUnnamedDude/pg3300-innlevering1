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
        private Snake snake;
        List<Food> FoodList;

        public GameBoard(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void spawnFood()
        {
            if (snake.Body.Count() + FoodList.Count() + 2 >= Width * Height)
            {
                GameOver = true;
                return;
            }
            while (true)
            {
                Food food = new Food(Width, Height);
                if (!snake.Body.Any(snakePart => snakePart.compare(food.Position)))
                {
                    FoodList.Add(food);
                    food.print();
                    return;
                }
            }
        }

        public void startGame()
        {
            snake = new Snake(this);
            FoodList = new List<Food>();
            Paused = false;
            GameOver = false;
            spawnFood();

            // Liker ikke game-loop koden, forslag?
            while (!GameOver)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                    if (consoleKey.Key == ConsoleKey.Escape)
                        GameOver = true;
                    else if (consoleKey.Key == ConsoleKey.Spacebar)
                        Paused = !Paused;
                    snake.setDirection(consoleKey);
                }
                if (Paused)
                    continue;

                snake.moveSnake();
                Thread.Sleep(100);
            }
        }

        public bool checkForFood(Coordinate coord)
        {
            return FoodList.Any(food => food.Position.compare(coord));
        }
    }
}
