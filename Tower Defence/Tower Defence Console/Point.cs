using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Point
    {
        public readonly int x;
        public readonly int y;


        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        public int DistanceTo(Point point)
        {
            return DistanceTo(point.x, point.y);
        }

        public int DistanceTo(int x, int y)
        {
            double xDifference = this.x - x;
            double yDifference = this.y - y;
            double xDifferenceSquared = xDifference * xDifference;
            double yDifferenceSquared = yDifference * yDifference;
            double result = Math.Sqrt(xDifferenceSquared + yDifferenceSquared);
            return (int)result;
        }
    }
}
