using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeMess
{
    public class Coordinate
    {
        public static readonly Coordinate UP = new Coordinate(0, -1);
        public static readonly Coordinate RIGHT = new Coordinate(1, 0);
        public static readonly Coordinate DOWN = new Coordinate(0, 1);
        public static readonly Coordinate LEFT = new Coordinate(-1, 0);

        public int X {get; private set;}
        public int Y {get; private set;}
        public Coordinate(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public Coordinate(Coordinate other) : this(other.X, other.Y)
        {
        }

        public bool isOpposite(Coordinate other)
        {
            Coordinate diff = this + other;
            return diff.X == 0 && diff.Y == 0;
        }

        //TODO: Replace with operator overflow
        public bool compare(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }

        public static Coordinate operator +(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.X + c2.X, c1.Y + c2.Y);
        }

        public static Coordinate operator -(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.X - c2.X, c1.Y - c2.Y);
        }

        /*public static bool operator ==(Coordinate c1, Coordinate c2)
        {
            return c1.X == c2.X && c1.Y == c2.Y;
        }

        public static bool operator !=(Coordinate c1, Coordinate c2)
        {
            return !(c1 == c2);
        }

        public static bool operator ==(Coordinate c1, int v)
        {
            return c1 == new Coordinate(v, v);
        }

        public static bool operator !=(Coordinate c1, int v)
        {
            return !(c1 == v);
        }*/

    }
}
