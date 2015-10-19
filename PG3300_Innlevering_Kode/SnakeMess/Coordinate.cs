using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeMess
{
	public class Coordinate
	{
	    public int X {get; set;}
	    public int Y {get; set;}
	    public Coordinate(int x = 0, int y = 0)
	    {
	        this.X = x;
	        this.Y = y;
	    }

        public Coordinate(Coordinate other)
        {
            this.X = other.X;
            this.Y = other.Y;
        }

		public static Coordinate operator +(Coordinate c1, Coordinate c2)
		{
			return new Coordinate(c1.X + c2.X, c1.Y + c2.Y);
		}

		public static Coordinate operator -(Coordinate c1, Coordinate c2)
		{
			return new Coordinate(c1.X - c2.X, c1.Y - c2.Y);
		}
    }
}
