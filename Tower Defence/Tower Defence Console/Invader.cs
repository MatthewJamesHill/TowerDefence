using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Invader
    {
        private readonly Path Path;
        private int PathStep = 0;
        private int HitPoints = 2;


        public Invader(Path Path)
        {
            this.Path = Path;
        }
                

        public MapLocation CurrentLocation => Path.GetLocationAt(PathStep);

        public bool HasScored => PathStep >= Path.Length && !IsDestroyed;

        public bool IsDestroyed => HitPoints <= 0;

        public bool IsActive => !(HasScored || IsDestroyed);


        public void Move()
        {
            PathStep++;
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }
    }
}
