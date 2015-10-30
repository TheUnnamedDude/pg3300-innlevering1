using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeMess
{
    public class RenderingFactory
    {
        public static readonly ConsoleColor FOOD_COLOR = ConsoleColor.Green;
        public static readonly char FOOD_SYMBOL = '$';

        public static readonly ConsoleColor SNAKE_COLOR = ConsoleColor.Yellow;
        public static readonly char HEAD_SYMBOL = '@';
        public static readonly char TAIL_SYMBOL = '0';

        public static Renderer createRenderer()
        {
            return new ConsoleRenderer();
        }

        public static Symbol headSymbol()
        {
            return new ConsoleSymbol(HEAD_SYMBOL, SNAKE_COLOR);
        }

        public static Symbol tailSymbol()
        {
            return new ConsoleSymbol(TAIL_SYMBOL, SNAKE_COLOR);
        }

        public static Symbol foodSymbol()
        {
            return new ConsoleSymbol(FOOD_SYMBOL, FOOD_COLOR);
        }

        public static Symbol emptySymbol()
        {
            return new ConsoleSymbol(' ');
        }
    }
}
