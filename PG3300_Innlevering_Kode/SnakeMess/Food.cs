using System;

namespace SnakeMess
{
    class Food
    {
        public static readonly char FOOD_SYMBOL = '$';
        public static readonly ConsoleColor FOOD_COLOR = ConsoleColor.Green;
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
