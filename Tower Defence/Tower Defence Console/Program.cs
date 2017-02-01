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


            // Instantiate level based on preceeding data
            Level Level = new Level(invaders, towers);


            // Check if player or invaders win
            bool result = Level.Play();


            // Inform player of result
            Console.WriteLine("You {0}!", result ? "win" : "lose");
            Console.ReadLine();
        }
    }
}
