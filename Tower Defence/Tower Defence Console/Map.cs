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


        public Map(int width, int height)
        {
            this.height = height;
            this.width = width;
        }

        public bool OnMap(Point point)
        {
            return point.x >= 0 &&
                   point.x < width &&
                   point.y >= 0 &&
                   point.y < height;
        }
        
        //TODO place this check in new tower locations class
        internal static bool IsTowerSpace(Tower[] towers, int h, int w)
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

        public void DrawMap(Path path, Tower[] towers)
        {
            Console.Clear();
            DrawHeader();
            DrawMapSpaces(path, towers);
            DrawFooter();
        }

        private void DrawHeader()
        {
            Console.WriteLine();
            Console.WriteLine("    Tower Defence Game!");
            Console.WriteLine();
            Console.WriteLine("      . _ . _ . _ . _ . _ . _ . _ . _ . _ . _ .");
        }

        private void DrawFooter()
        {
            Console.WriteLine("        0   1   2   3   4   5   6   7   8   9");
            Console.WriteLine();
            Console.WriteLine();
        }

        private void DrawMapSpaces(Path path, Tower[] towers)
        {
            for (int h = height - 1; h >= 0; h--)
            {
                Console.Write("    " + h + " ");

                for (int w = 0; w < width; w++)
                {
                    // Check for base location at end of path
                    if (h == path.GetBaseLocation().y &&
                        w == path.GetBaseLocation().x)
                    {
                        Console.Write("| B ");
                    }

                    // Check for invader location (currently always start of path)
                    else if (h == path.GetLocationAt(0).y &&
                             w == path.GetLocationAt(0).x)
                    {
                        Console.Write("| I ");
                    }

                    else if (path.IsOnPath(w, h))
                    {
                        Console.Write("| P ");
                    }

                    else if (IsTowerSpace(towers, h, w))
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
        }
    }
}
