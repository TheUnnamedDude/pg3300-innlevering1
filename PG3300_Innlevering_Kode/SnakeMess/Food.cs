using System;

namespace SnakeMess
{
    class Food
    {
        public static readonly char FOOD_SYMBOL = '$';
        public static readonly ConsoleColor FOOD_COLOR = ConsoleColor.Green;
        public Coordinate Position
        {
            get; private set;
        }

        public Food(Coordinate position)
        {
            Position = position;
        }
    }
}
