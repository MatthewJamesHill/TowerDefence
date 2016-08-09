using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    /// <summary>
    /// Contains map dimensions,
    /// Methods for drawing the map and checking if locations are on the map
    /// </summary>
    class Map
    {
        /// <summary>
        /// X, Y axes of map
        /// </summary>
        /// <remarks>
        /// Written in absolute terms: 1, 10 NOT 0, 9 </remarks>
        public readonly int Width;
        public readonly int Height;


        /// <summary>
        /// Default map constructor
        /// </summary>
        /// <param name="width"> X axis value </param>
        /// <param name="height"> Y axis value </param>
        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }


        /// <summary>
        /// Check a point to see if it is within map boundaries
        /// </summary>
        /// <param name="point">  </param>
        /// <returns> True if point on map, else false </returns>
        public bool OnMap(Point point)
        {
            return point.X >= 0 && point.X < Width &&
                   point.Y >= 0 && point.Y < Height;
        }


        /// <summary>
        /// Clears screen and draws new map in console
        /// Generates map procedurally by checking locations of Invaders, Towers, Path, Base
        /// </summary>
        /// <param name="path"> Value passed to IsOccupied method </param>
        /// <param name="towers"> Value passed to IsOccupied method </param>
        public void DrawMap(Path path, Tower[] towers)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("    Tower Defence Game!");
            Console.WriteLine();

            Console.WriteLine("      . _ . _ . _ . _ . _ . _ . _ . _ . _ . _ .");

            for (int h = Height - 1; h >= 0; h--)
            {
                Console.Write("    " + h + " ");

                for (int w = 0; w < Width; w++)
                {
                    // Check for base location at end of path
                    if (h == path.path[path.Length - 1].Y &&
                        w == path.path[path.Length - 1].X)
                    {
                        Console.Write("| B ");
                    }

                    // Check for invader location (currently always start of path)
                    else if (h == path.path[0].Y &&
                             w == path.path[0].X)
                    {
                        Console.Write("| I ");
                    }

                    // Check if path space
                    else if (IsOccupied(path, h, w))
                    {
                        Console.Write("| P ");
                    }

                    // check if tower space
                    else if (IsOccupied(towers, h, w))
                    {
                        Console.Write("| T ");
                    }

                    else
                    {
                        Console.Write("| _ ");
                    }
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("        0   1   2   3   4   5   6   7   8   9");
            Console.WriteLine();
            Console.WriteLine();
        }


        /// <summary>
        /// Checks if space on map is occupied by path space
        /// </summary>
        /// <param name="path"></param>
        /// <param name="h"> Height value, equates to Y </param>
        /// <param name="w"> Width value, equates to X </param>
        /// <returns> True if h, w and X, Y match, else false </returns>
        internal static bool IsOccupied(Path path, int h, int w)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (path.path[i].X == w && path.path[i].Y == h) { return true; }
            }

            return false;
        }


        /// <summary>
        /// Checks if space on map is occupied by tower
        /// </summary>
        /// <param name="path"></param>
        /// <param name="h"> Height value, equates to Y </param>
        /// <param name="w"> Width value, equates to X </param>
        /// <returns> True if h, w and X, Y of any tower match, else false </returns>
        internal static bool IsOccupied(Tower[] towers, int h, int w)
        {
            int counter = 0;

            // Sets counter to number of Towers in array to prevent index error
            for (int i = 0; i < towers.Length; i++)
            {
                if (towers[i] != null) { counter++; }
            }

            // Loops through all *existing* towers
            for (int i = 0; i < counter; i++)
            {
                if (towers[i]._location.X == w && towers[i]._location.Y == h) { return true; }
            }

            return false;
        }
    }
}
