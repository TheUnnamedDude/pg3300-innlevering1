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

        public Food(int maxWidth, int maxHeight)
        {
            Random random = new Random();
            Position = new Coordinate(random.Next(0, maxWidth), random.Next(0, maxHeight));
        }

        public void print()
        {
            Position.printElement(FOOD_SYMBOL, FOOD_COLOR);
        }
    }
}
