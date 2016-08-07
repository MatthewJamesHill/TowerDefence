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


            Tower[] towers = new Tower[3];
            map.DrawMap(path, towers);


            // Allow user to place own towers
            towers[0] = Tower.GenerateNewTower(map, path);
            map.DrawMap(path, towers);

            towers[1] = Tower.GenerateNewTower(map, path);
            map.DrawMap(path, towers);

            towers[2] = Tower.GenerateNewTower(map, path);
            map.DrawMap(path, towers);


            Level Level = new Level(invaders, towers);

            bool result = Level.Play();

            Console.WriteLine("You {0}!", result ? "win" : "lose");
            Console.ReadLine();



        }
    }
}
