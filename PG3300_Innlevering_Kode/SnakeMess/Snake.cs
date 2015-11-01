using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess
{
    class Snake
    {

        private Coordinate direction = Coordinate.DOWN;

        public List<Coordinate> Body
        {
            get; private set;
        }
        public Coordinate HeadPosition
        {
            get; set;
        }

        public Snake()
        {
            Body = new List<Coordinate>();
            Coordinate baseCoordinate = new Coordinate(10, 10);
            Body.Add(baseCoordinate);
            Body.Add(baseCoordinate);
            Body.Add(baseCoordinate);
            Body.Add(baseCoordinate);
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
            if (direction + newDir != 0)
                direction = newDir;
        }

        public void moveSnake()
        {
            Body.Add(HeadPosition);
            HeadPosition += direction;
            Body.RemoveAt(0);
        }
        public bool collisionCheck(int width, int height)//or can be passed point to check
        {
            return Body.Contains(HeadPosition)
                    || HeadPosition.X < 0 || HeadPosition.Y < 0
                    || HeadPosition.X >= width
                    || HeadPosition.Y >= height; // Death by bounds
        }
        public void grow()
        {
            Body.Add(Body.Last());
        }
    }
}
