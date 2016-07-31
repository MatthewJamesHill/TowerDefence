using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class MapLocation : Point
    {
        // Constructor
        public MapLocation(int x, int y, Map map) : base(x, y)
        {
            if (!map.OnMap(this))
            {
                throw new Exception(string.Format("Location {0}, {1} is out of bounds.", x, y));
            }
        }


        // Methods
        public bool InRange(MapLocation location, int range)
        {
            return range >= DistanceTo(location);
        }
    }
}
