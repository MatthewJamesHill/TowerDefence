using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    /// <summary>
    /// The path the invaders must take to reach the base
    /// </summary>
    class Path
    {
        /// <summary>
        /// Array of locations that make up the path
        /// </summary>
        public readonly MapLocation[] path;


        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="path"> Sets the encapsulated path </param>
        public Path(MapLocation[] path)
        {
            this.path = path;
        }


        /// <summary>
        /// Length of the path (Length -1 if used as an index)
        /// </summary>
        public int Length => path.Length;


        /// <summary>
        /// Sets invader location to current progress along the path
        /// </summary>
        /// <param name="pathStep"> Progress of invader along the path </param>
        /// <returns> Single maplocation from the path array </returns>
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


        /// <summary>
        /// Check if a location conflicts with the path
        /// </summary>
        /// <param name="location"> Location to be checked against </param>
        /// <returns> True if location is on path, else false </returns>
        public bool OnPath(MapLocation location)
        {
            return path.Contains(location);
        }
    }
}
