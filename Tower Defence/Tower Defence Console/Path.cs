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

        public bool IsOnPath(int x, int y)
        {
            foreach (MapLocation pathLocation in path)
            {
                if (pathLocation.x == x &&
                    pathLocation.y == y)
                {
                    return true;
                }               
            }
            return false;
        }


        public bool IsBaseLocation(MapLocation location)
        {
            MapLocation baseLocation = GetBaseLocation();
            return baseLocation.x == location.x &&
                   baseLocation.y == location.y;
        }

        public bool IsBaseLocation(int x, int y)
        {
            MapLocation baseLocation = GetBaseLocation();
            return baseLocation.x == x &&
                   baseLocation.y == y;
        }

        private MapLocation GetBaseLocation()
        {
            return path[path.Length - 1];
        }


        public bool IsInvaderStartLocation(MapLocation location)
        {
            MapLocation invaderStartLocation = GetInvaderStartLocation();
            return invaderStartLocation.x == location.x &&
                   invaderStartLocation.y == location.y;
        }

        public bool IsInvaderStartLocation(int x, int y)
        {
            MapLocation invaderStartLocation = GetInvaderStartLocation();
            return invaderStartLocation.x == x &&
                   invaderStartLocation.y == y;
        }

        private MapLocation GetInvaderStartLocation()
        {
            return path[0];
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
    }
}
