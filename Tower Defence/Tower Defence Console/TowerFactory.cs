using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    sealed class TowerFactory
    {
        public static Tower GenerateNewTower(Map map, Path path)
        {
            while (true)
            {
                Console.Write("Enter the X coordinates of your tower: ");
                string inputX = Console.ReadLine();

                Console.WriteLine();
                Console.Write("Enter the Y coordinates of your tower: ");
                string inputY = Console.ReadLine();

                int x;
                int y;

                try
                {
                    x = Convert.ToInt32(inputX);
                    y = Convert.ToInt32(inputY);
                }

                // Currently only catches bad input, not conflicting locations
                catch (FormatException ex)
                {

                    Console.WriteLine("Invalid input!");
                    continue;
                }

                MapLocation LocationForTower = new MapLocation(x, y, map);

                if (!map.OnMap(LocationForTower) || !path.IsOnPath(LocationForTower))
                {
                    throw new Exception("Location not on map or is on path.");
                }

                return new Tower(LocationForTower);
            }
        }
    }
}
