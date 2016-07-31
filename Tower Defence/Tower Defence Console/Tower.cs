﻿using System;
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

        private readonly MapLocation _location;

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
    }
}