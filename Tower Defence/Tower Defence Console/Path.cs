using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Path
    {
        // Fields
        private readonly MapLocation[] _path;


        // Constructor
        public Path(MapLocation[] path)
        {
            _path = path;
        }


        // Properties
        public int Length => _path.Length;


        // Methods
        public MapLocation GetLocationAt(int pathStep)
        {
            if (pathStep < Length)
            {
                return _path[pathStep];
            }

            else // Continue to return end step on path (score location)
            {
                return _path[_path.Length-1];
            }
        }

        public bool OnPath(MapLocation location)
        {
            return _path.Contains(location);
        }
    }
}
