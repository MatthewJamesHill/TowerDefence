using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    /// <summary>
    /// The tower can shoot at invaders,
    /// And must not be placed on the path
    /// </summary>
    class Tower
    {
        // Fields
        private static readonly Random _random = new Random();

        public readonly MapLocation _location;

        private const int _range = 1;
        private const int _strength = 1;
        private const double _accuracy = .75;


        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="location"> Location to place tower at </param>
        /// <param name="map"> Map to place tower on </param>
        /// <param name="path"> Path for tower to not conflict with </param>
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


        /// <summary>
        /// Check if shot hits or misses based on accuracy and random chance
        /// </summary>
        /// <returns> True if shot hits, false if not </returns>
        private bool SuccessfulShot() => _accuracy <= _random.Next();


        /// <summary>
        /// Shoot at each invader if they are active, in range, and haven't scored
        /// </summary>
        /// <param name="invaders"> Invaders to shoot at </param>
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


        /// <summary>
        /// Generates new instance of tower based on user defined locations
        /// </summary>
        /// <param name="map"> Map to place tower on </param>
        /// <param name="path"> Path to send to default constructor </param>
        /// <returns> New instance of tower class </returns>
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
