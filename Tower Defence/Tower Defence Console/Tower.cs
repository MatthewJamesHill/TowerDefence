using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Tower
    {
        public readonly MapLocation _location;

        private const int _range = 1;
        private const int _strength = 1;
        private const double _accuracy = .75;
        private static readonly Random _random = new Random();


        public Tower(MapLocation Location)
        {
            _location = Location;
        }


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
    }
}
