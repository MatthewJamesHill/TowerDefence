using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    /// <summary>
    /// Point based locations on the map
    /// </summary>
    class MapLocation : Point
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="x"> X axis location </param>
        /// <param name="y"> Y axis location </param>
        /// <param name="map"> Map to check boundaries against </param>
        public MapLocation(int x, int y, Map map) : base(x, y)
        {
            // First check if location is on map
            if (!map.OnMap(this))
            {
                throw new Exception(string.Format("Location {0}, {1} is out of bounds.", x, y));
            }
        }


        /// <summary>
        /// Check if another maplocation is in range of this one
        /// </summary>
        /// <param name="location"> Other location </param>
        /// <param name="range"> Range of tower </param>
        /// <returns> True if range is greater than distance, else false </returns>
        public bool InRange(MapLocation location, int range)
        {
            return range >= DistanceTo(location);
        }
    }
}
