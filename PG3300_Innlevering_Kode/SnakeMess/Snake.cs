using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Snake
    {

        private Coordinate direction = Coordinate.DOWN;
        private GameBoard gameBoard;

        public List<Coordinate> Body
        {
            get; private set;
        }
        public Coordinate HeadPosition
        {
            get; set;
        }

        public Snake(GameBoard gameBoard)
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
            if (!direction.isOpposite(newDir))
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
            if (gameBoard.checkForFood(HeadPosition))
            {
                Body.Add(Body.First());
                gameBoard.eatFood(HeadPosition);
            }
        }
        public bool collisionCheck()//or can be passed point to check
        {
            return Body.Any(coord => coord.compare(HeadPosition))
                    || HeadPosition.X < 0 || HeadPosition.Y < 0
                    || HeadPosition.X >= gameBoard.Width
                    || HeadPosition.Y >= gameBoard.Height; // Death by bounds
        }
    }
}
