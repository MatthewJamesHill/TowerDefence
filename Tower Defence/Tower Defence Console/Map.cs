using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Map
    {
        //Fields
        public readonly int Width;
        public readonly int Height;


        // Constructor
        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }


        // Methods
        public bool OnMap(Point point)
        {
            return point.X >= 0 && point.X < Width &&
                   point.Y >= 0 && point.Y < Height;
        }
    }
}
