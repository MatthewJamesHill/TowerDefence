using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Tower
    {
        public readonly MapLocation TowerLocation;

        private const int WeaponRange = 1;
        private const int WeaponStrength = 1;
        private const double WeaponAccuracy = .75;
        private static readonly Random WeaponMissChance = new Random();


        public Tower(MapLocation Location)
        {
            TowerLocation = Location;
        }


        public void ShootAtInvaders(Invader[] invaders)
        {
            foreach (Invader invader in invaders)
            {
                if (invader.IsActive && invader.Location.IsInRange(TowerLocation, WeaponRange))
                {
                    AttemptShot(invader);
                    break;
                }
            }
        }

        private void AttemptShot(Invader invader)
        {
            if (WeaponAccuracy <= WeaponMissChance.Next())
            {
                invader.TakeDamage(WeaponStrength);
            }
        }        
    }
}
