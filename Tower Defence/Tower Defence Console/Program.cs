using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate map
            Map map = new Map(10, 10);

            // Generate path for invaders to follow
            Path path = new Path(
                new[] {
                new MapLocation(0, 4, map),
                new MapLocation(1, 4, map),
                new MapLocation(2, 4, map),
                new MapLocation(3, 4, map),
                new MapLocation(4, 4, map),
                new MapLocation(5, 4, map),
                new MapLocation(6, 4, map),
                new MapLocation(7, 4, map),
                new MapLocation(8, 4, map),
                new MapLocation(9, 4, map),
                    }
                );
            
            // Generate invaders for level
            Invader[] invaders =
            {
            new Invader(path),
            new Invader(path),
            new Invader(path),
            new Invader(path),
            };

            // Standard set of towers
            /*
                        Tower[] towers =
                {
                new Tower(new MapLocation(1, 3, map), map, path),
                new Tower(new MapLocation(3, 3, map), map, path),
                new Tower(new MapLocation(5, 3, map), map, path),
                };
            */
            Console.WriteLine();
            Console.WriteLine("Tower Defence Game!");
            Console.WriteLine();
            Console.WriteLine("  . _ . _ . _ . _ . _ . _ . _ . _ . _ . _ .");
            Console.WriteLine("9 | _ | _ | _ | _ | _ | _ | _ | _ | _ | _ |");
            Console.WriteLine("8 | _ | _ | _ | _ | _ | _ | _ | _ | _ | _ |");
            Console.WriteLine("7 | _ | _ | _ | _ | _ | _ | _ | _ | _ | _ |");
            Console.WriteLine("6 | _ | _ | _ | _ | _ | _ | _ | _ | _ | _ |");
            Console.WriteLine("5 | _ | _ | _ | _ | _ | _ | _ | _ | _ | _ |");
            Console.WriteLine("4 | I | P | P | P | P | P | P | P | P | B |");
            Console.WriteLine("3 | _ | _ | _ | _ | _ | _ | _ | _ | _ | _ |");
            Console.WriteLine("2 | _ | _ | _ | _ | _ | _ | _ | _ | _ | _ |");
            Console.WriteLine("1 | _ | _ | _ | _ | _ | _ | _ | _ | _ | _ |");
            Console.WriteLine("0 | _ | _ | _ | _ | _ | _ | _ | _ | _ | _ |");
            Console.WriteLine("    0   1   2   3   4   5   6   7   8   9");
            Console.WriteLine();
            Console.WriteLine("I: Invader start position.");
            Console.WriteLine("P: The path the invaders will take.");
            Console.WriteLine("B: Your base, protect it.");
            Console.WriteLine();

            // Allow user to place own towers
            Tower[] towers =
            {
                Tower.GenerateNewTower(map, path),
                Tower.GenerateNewTower(map, path),
                Tower.GenerateNewTower(map, path),
            };


            Level Level = new Level(invaders, towers);

            bool result = Level.Play();

            Console.WriteLine("You {0}!", result ? "win" : "lose");
            Console.ReadLine();



        }
    }
}
