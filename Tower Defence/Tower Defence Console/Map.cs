using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Map
    {
        private readonly int height;
        private readonly int width;
        private readonly Path path;


        public Map(int width, int height, Path path)
        {
            this.height = height;
            this.width = width;
            this.path = path;
        }

        public bool OnMap(Point point)
        {
            return point.x >= 0 && point.x < width &&
                   point.y >= 0 && point.y < height;
        }

        public void DrawMap(Path path, Tower[] towers)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("    Tower Defence Game!");
            Console.WriteLine();

            Console.WriteLine("      . _ . _ . _ . _ . _ . _ . _ . _ . _ . _ .");

            for (int h = height - 1; h >= 0; h--)
            {
                Console.Write("    " + h + " ");

                for (int w = 0; w < width; w++)
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


        internal static bool IsOccupied(Path path, int h, int w)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (path.path[i].X == w && path.path[i].Y == h) { return true; }
            }

            return false;
        }

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
                if (towers[i]._location.x == w && towers[i]._location.y == h) { return true; }
            }

            return false;
        }
    }
}
