using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class MapLocation : Point
    {
        public MapLocation(int x, int y, Map map) : base(x, y)
        {
            // First check if location is on map
            if (!map.OnMap(this))
            {
                throw new Exception(string.Format("Location {0}, {1} is out of bounds.", x, y));
            }
        }

        public bool IsInRange(MapLocation location, int range)
        {
            return range >= DistanceTo(location);
        }
    }
}
