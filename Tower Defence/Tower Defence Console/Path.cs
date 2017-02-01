using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Path
    {
        private readonly MapLocation[] path;


        public Path(MapLocation[] path)
        {
            this.path = path;
        }


        public int Length => path.Length;


        public bool IsOnPath(MapLocation location)
        {
            return path.Contains(location);
        }

        public MapLocation GetLocationAt(int pathStep)
        {
            if (pathStep < Length)
            {
                return path[pathStep];
            }
            else
            {
                return GetBaseLocation();
            }
        }

        public MapLocation GetBaseLocation()
        {
            return path[path.Length - 1];
        }
    }
}
