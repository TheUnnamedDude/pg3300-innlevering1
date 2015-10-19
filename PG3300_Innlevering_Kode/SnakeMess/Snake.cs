using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Snake
    {
        List<Coordinate> body;
        char headSymbol = '@';
        char tailSymbol = '0';
        Coordinate headPosition { get; }

        Coordinate direction = Coordinate.DOWN;

        public List<Coordinate> Body
        {
            get
            {
                return body;
            }
        }
        public Coordinate HeadPosition {
            get
            {
                return body.Last();
            }
        }

        public Snake()
        {
            body = new List<Coordinate>();
        }
        public void setDirection(ConsoleKeyInfo cki)
        {
            if (cki.Key == ConsoleKey.UpArrow && !direction.isOpposite(Coordinate.UP))
                direction = Coordinate.UP;
            else if (cki.Key == ConsoleKey.RightArrow && !direction.isOpposite(Coordinate.RIGHT))
                direction = Coordinate.RIGHT;
            else if (cki.Key == ConsoleKey.DownArrow && !direction.isOpposite(Coordinate.DOWN))
                direction = Coordinate.DOWN;
            else if (cki.Key == ConsoleKey.LeftArrow && !direction.isOpposite(Coordinate.LEFT))
                direction = Coordinate.LEFT;
        }
        public void moveSnake()
        {
            Coordinate tail = new Coordinate(body.First());
            Coordinate head = new Coordinate(body.Last());
            Coordinate newH = new Coordinate(head);
            newH += direction;
            body.RemoveAt(0);


        }
        public bool collisionCheck()//or can be passed point to check
        {
            foreach (Coordinate x in body)
                if (x.X == body.Last().X && x.Y == body.Last().Y)
                {
                    // Death by accidental self-cannibalism.
                    return true;
                }
            return false;
        }


    }
}
