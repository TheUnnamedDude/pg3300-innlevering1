using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess
{
    class Snake
    {

        private Coordinate direction = Coordinate.DOWN;
        private SnakeBoard gameBoard;

        public List<Coordinate> Body
        {
            get; private set;
        }
        public Coordinate HeadPosition
        {
            get; set;
        }

        public Snake(SnakeBoard gameBoard)
        {
            this.gameBoard = gameBoard;
            Body = new List<Coordinate>();
            Coordinate baseCoordinate = new Coordinate(10, 10);
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
            if (collisionCheck())
            {
                gameBoard.GameOver = true;
                return;
            }

            //Remove tail
            gameBoard.renderer.render(RenderingFactory.emptySymbol(), Body.First());
            Body.RemoveAt(0);

            // Move head and write the correct body symbol
            gameBoard.renderer.render(RenderingFactory.tailSymbol(), Body.Last());
            gameBoard.renderer.render(RenderingFactory.headSymbol(), HeadPosition);
            
        }
        public bool collisionCheck()//or can be passed point to check
        {
            return Body.Contains(HeadPosition)
                    || HeadPosition.X < 0 || HeadPosition.Y < 0
                    || HeadPosition.X >= gameBoard.Width
                    || HeadPosition.Y >= gameBoard.Height; // Death by bounds
        }
        public void grow()
        {
            Body.Add(Body.Last());
        }
    }
}
