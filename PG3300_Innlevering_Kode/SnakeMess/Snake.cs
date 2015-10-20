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
            Console.SetCursorPosition(body.First().X, body.First().Y);
            Console.Write(" ");
            body.RemoveAt(0);

            // Move head and write the correct body symbol
            Console.SetCursorPosition(body.Last().X, Body.Last().Y);
            Console.Write(TAIL_SYMBOL);
            Console.SetCursorPosition(HeadPosition.X, HeadPosition.Y);
            Console.Write(HEAD_SYMBOL);

        }
        public bool collisionCheck()//or can be passed point to check
        {
            /*foreach (Coordinate x in body)
                if (x.X == HeadPosition.X && x.Y == HeadPosition.Y)
                {
                    // Death by accidental self-cannibalism.
                    return true;
                }*/
            return body.Any(coord => coord.X == HeadPosition.X && coord.Y == HeadPosition.Y)
                    || HeadPosition.X < 0 || HeadPosition.Y < 0
                    || HeadPosition.X >= _gameBoard.Width
                    || HeadPosition.Y >= _gameBoard.Height; // Death by bounds
        }
    }
}
