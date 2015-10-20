using System;

namespace SnakeMess
{
    class Food
    {
        char foodSymbol = '$';
        Coordinate position;

        public Food(Coordinate position)
        {
            Position = position;
        }
        public Coordinate Position
        {
            get; set;
        }
        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("$");
            Console.ResetColor();
        }
    }
}
