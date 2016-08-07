using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Tower
    {
        // Fields
        private static readonly Random _random = new Random();

        public readonly MapLocation _location;

        private const int _range = 1;
        private const int _strength = 1;
        private const double _accuracy = .75;


        // Constructor
        public Tower(MapLocation location, Map map, Path path)
        {
            if (!map.OnMap(location) || path.OnPath(location))
            {
                throw new Exception("Location not on map or is on path.");
            }
            else
            {
                _location = location;
            }
        }


        // Methods
        private bool SuccessfulShot() => _accuracy <= _random.Next();

        public void DamageInvaders(Invader[] invaders)
        {
            foreach (Invader invader in invaders)
            {
                if (invader.IsActive && !invader.HasScored && _location.InRange(invader.Location, _range))
                {
                    if (SuccessfulShot())
                    {
                        invader.TakeDamage(_strength);
                    }
                    break;
                }
            }
        }

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
                catch (Exception)
                {

                    Console.WriteLine("Invalid input!");
                    continue;
                }

                return new Tower(new MapLocation(x, y, map), map, path);
            }
        }
    }
}
