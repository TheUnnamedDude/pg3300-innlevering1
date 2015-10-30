using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeMess
{
    public class ConsoleSymbol : Symbol
    {
        private ConsoleColor color;
        private char symbol;
        public ConsoleSymbol(char symbol, ConsoleColor color = ConsoleColor.White)
        {
            this.color = color;
            this.symbol = symbol;
        }

        public void draw()
        {
            Console.ForegroundColor = color;
            Console.Write(symbol);
        }
    }
}
