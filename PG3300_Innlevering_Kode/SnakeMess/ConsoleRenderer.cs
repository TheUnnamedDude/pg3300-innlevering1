using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeMess
{
    public class ConsoleRenderer : Renderer
    {
        Renderer ren;
        public void render(Symbol symbol, Coordinate coord)
        {
            Console.SetCursorPosition(coord.X, coord.Y);
            symbol.draw();
        }
    }
}
