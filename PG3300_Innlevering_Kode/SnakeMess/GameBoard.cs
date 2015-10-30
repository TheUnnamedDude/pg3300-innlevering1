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
        public Renderer renderer;
        List<Food> FoodList;

        public GameBoard(int width, int height, Renderer renderer)
        {
            this.Width = width;
            this.Height = height;
            this.renderer = renderer;
        }

        public void eatFood(Coordinate foodPos)
        {
            FoodList.Remove(FoodList.Find(food => food.Position == foodPos));
            spawnFood();
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
                if (!snake.Body.Any(snakePart => food.Position == snakePart))
                {
                    FoodList.Add(food);
                    renderer.render(RenderingFactory.foodSymbol(), food.Position);
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
            return FoodList.Any(food => food.Position == coord);
        }
    }
}
