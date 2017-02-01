using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Path
    {
        public readonly MapLocation[] path;

        public Path(MapLocation[] path)
        {
            this.path = path;
        }

        public int Length => path.Length;

        public MapLocation GetLocationAt(int pathStep)
        {
            if (pathStep < Length)
            {
                return path[pathStep];
            }

            // Continue to return base location
            else
            {
                return path[path.Length-1];
            }
        }

        public bool OnPath(MapLocation location)
        {
            return path.Contains(location);
        }
    }
}
