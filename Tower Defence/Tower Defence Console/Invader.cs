using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Invader
    {
        // Fields
        private readonly Path _path;
        private int _pathStep = 0;


        // Constructor
        public Invader(Path path)
        {
            _path = path;
        }


        // Properties
        public int HitPoints { get; private set; } = 2;

        public MapLocation Location => _path.GetLocationAt(_pathStep);

        public bool HasScored => _pathStep >= _path.Length && !IsDestroyed;

        public bool IsDestroyed => HitPoints <= 0;

        public bool IsActive => !(HasScored || IsDestroyed);


        // Methods
        public void Move() => _pathStep++;

        public void TakeDamage(int damage) => HitPoints -= damage;
    }
}
