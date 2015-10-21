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
        Random random;


        public void spawnFood()
        {
            if (snake.Body.Count() + FoodList.Count() + 2 >= Width * Height)
            {
                GameOver = true;
                return;
            }
            while (true)
            {
                random= new Random();
                Coordinate foodCoord = new Coordinate(random.Next(0, Width), random.Next(0, Height));
                if (!snake.Body.Any(snakePart => snakePart.compare(foodCoord)))
                {
                    FoodList.Add(new Food(foodCoord));
                    PrintElement(foodCoord, Food.FOOD_SYMBOL, Food.FOOD_COLOR);
                    return;
                }
            }
        }

        public void PrintElement(Coordinate coord, char c, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write(c);
        }

        public GameBoard(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void StartGame()
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
