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
            Map map = new Map(10, 10);

            Path path = new Path(
                new[] {
                new MapLocation(0, 2, map),
                new MapLocation(1, 2, map),
                new MapLocation(2, 2, map),
                new MapLocation(3, 2, map),
                new MapLocation(4, 2, map),
                new MapLocation(5, 2, map),
                new MapLocation(6, 2, map),
                new MapLocation(7, 2, map),
                new MapLocation(8, 2, map),
                new MapLocation(9, 2, map),
                }
            );

            Invader[] invaders =
            {
                new Invader(path),
                new Invader(path),
                new Invader(path),
                new Invader(path),
            };

            Tower[] towers =
            {
                new Tower(new MapLocation(1, 3, map), map, path),
                new Tower(new MapLocation(3, 3, map), map, path),
                new Tower(new MapLocation(5, 3, map), map, path),
            };

            Level level1 = new Level(invaders)
            {
                Towers = towers
            };

            bool result = level1.Play();

            Console.WriteLine("You {0}!", result ? "win" : "lose");
            Console.ReadLine();
        }
    }
}
