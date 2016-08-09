using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    /// <summary>
    /// Single X, Y point on the map
    /// </summary>
    class Point
    {
        // X, Y Fields
        public readonly int X;
        public readonly int Y;


        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="x"> Sets the location on the X axis </param>
        /// <param name="y"> Sets the location on the Y axis </param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// Calculates the distance between this point and an X, Y location
        /// </summary>
        /// <param name="x"> X axis of other point </param>
        /// <param name="y"> Y axis of other point </param>
        /// <returns> Int distance between point and x, y based on Cartesian Distance Formula </returns>
        public int DistanceTo(int x, int y)
        {
            double xDiffSquared = Math.Pow(X - x, 2);
            double yDiffSquared = Math.Pow(Y - y, 2);
            return (int)Math.Sqrt(xDiffSquared + yDiffSquared);
        }


        /// <summary>
        /// Calculates the distance between this point and another
        /// </summary>
        /// <param name="point"> Location of other point </param>
        /// <returns> Int distance between this point and other point based on Cartesian Distance Formula </returns>
        public int DistanceTo(Point point)
        {
            return DistanceTo(point.X, point.Y);
        }
    }
}
