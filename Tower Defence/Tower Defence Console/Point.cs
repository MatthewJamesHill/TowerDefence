using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Point
    {
        // Fields
        public readonly int X;
        public readonly int Y;


        // Constructor
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }


        // Methods
        public int DistanceTo(int x, int y)
        {
            // Return distance between point and x, y based on Cartesian Distance Formula
            double xDiffSquared = Math.Pow(X - x, 2);
            double yDiffSquared = Math.Pow(Y - y, 2);
            return (int)Math.Sqrt(xDiffSquared + yDiffSquared);
        }

        public int DistanceTo(Point point)
        {
            // Overload that accepts value of type Point as argument
            return DistanceTo(point.X, point.Y);
        }
    }
}
