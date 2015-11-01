using System;

namespace SnakeMess
{
    class Food
    {
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
    }
}