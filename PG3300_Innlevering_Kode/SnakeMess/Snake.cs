using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Snake
    {
        List<Coordinate> body;
        public static readonly char HEAD_SYMBOL = '@';
        public static readonly char TAIL_SYMBOL = '0';
        public static readonly ConsoleColor SNAKE_COLOR = ConsoleColor.Yellow;

        Coordinate direction = Coordinate.DOWN;
        private GameBoard _gameBoard;

        public List<Coordinate> Body
        {
            get
            {
                return body;
            }
        }
        public Coordinate HeadPosition {
            get;set;
        }

        public Snake(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            body = new List<Coordinate>();
            Coordinate baseCoordinate = new Coordinate(10, 10);
            body.Add(baseCoordinate);
            body.Add(baseCoordinate);
            body.Add(baseCoordinate);
            HeadPosition = baseCoordinate;
        }
        public void setDirection(ConsoleKeyInfo cki)
        {
            Coordinate newDir = direction;
            if (cki.Key == ConsoleKey.UpArrow)
                newDir = Coordinate.UP;
            else if (cki.Key == ConsoleKey.RightArrow)
                newDir = Coordinate.RIGHT;
            else if (cki.Key == ConsoleKey.DownArrow)
                newDir = Coordinate.DOWN;
            else if (cki.Key == ConsoleKey.LeftArrow)
                newDir = Coordinate.LEFT;
            if (!direction.isOpposite(newDir))
                direction = newDir;
        }

        public void moveSnake()
        {
            body.Add(HeadPosition);
            HeadPosition += direction;
            if (collisionCheck())
            {
                _gameBoard.GameOver = true;
                return;
            }

            //Remove tail
            _gameBoard.PrintElement(body.First(), ' ');
            Console.SetCursorPosition(body.First().X, body.First().Y);
            Console.Write(" ");
            body.RemoveAt(0);

            // Move head and write the correct body symbol
            _gameBoard.PrintElement(body.Last(), TAIL_SYMBOL, SNAKE_COLOR);
            _gameBoard.PrintElement(HeadPosition, HEAD_SYMBOL, SNAKE_COLOR);
            if (_gameBoard.CheckForFood(HeadPosition))
            {
                Body.Add(Body.First());
                _gameBoard.SpawnFood();
            }
        }
        public bool collisionCheck()//or can be passed point to check
        {
            /*foreach (Coordinate x in body)
                if (x.X == HeadPosition.X && x.Y == HeadPosition.Y)
                {
                    // Death by accidental self-cannibalism.
                    return true;
                }*/
            return body.Any(coord => coord.compare(HeadPosition))
                    || HeadPosition.X < 0 || HeadPosition.Y < 0
                    || HeadPosition.X >= _gameBoard.Width
                    || HeadPosition.Y >= _gameBoard.Height; // Death by bounds
        }
    }
}
