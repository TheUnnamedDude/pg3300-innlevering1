using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeMess
{
    public interface Renderer
    {
        void render(Symbol symbol, Coordinate coord);
    }
}
