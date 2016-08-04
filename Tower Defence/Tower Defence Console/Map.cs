using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Map
    {
        //Fields
        public readonly int Width;
        public readonly int Height;


        // Constructor
        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }


        // Methods
        public bool OnMap(Point point)
        {
            return point.X >= 0 && point.X < Width &&
                   point.Y >= 0 && point.Y < Height;
        }

        public void DrawMap(Path path)
        {
            Console.WriteLine();
            Console.WriteLine("    Tower Defence Game!");
            Console.WriteLine();

            Console.WriteLine("      . _ . _ . _ . _ . _ . _ . _ . _ . _ . _ .");

            for (int h = Height - 1; h >= 0; h--)
            {
                Console.Write("    " + h + " ");

                for (int w = 0; w < Width; w++)
                {
                    if (h == path._path[path.Length - 1].Y &&
                        w == path._path[path.Length - 1].X)
                    {
                        Console.Write("| B ");
                    }

                    else if (h == path._path[0].Y &&
                             w == path._path[0].X)
                    {
                        Console.Write("| I ");
                    }

                    else if (h >= path._path[0].Y &&
                             h <= path._path[path.Length - 1].Y &&
                             w > path._path[0].X &&
                             w < path._path[path.Length - 1].X)
                    {
                        Console.Write("| P ");  // Currently only draws in straight line!
                    }

                    // else if towers

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
    }
}
