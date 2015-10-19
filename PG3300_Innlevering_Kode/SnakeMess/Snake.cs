using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Snake
    {
        List<Coordinate> body = new List<Coordinate>();
        char headSymbol = '@';
        char tailSymbol = '0';
        Coordinate headPosition;

        Coordinate direction = Coordinate.DOWN;

        public Snake()
        {

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

    }
}
