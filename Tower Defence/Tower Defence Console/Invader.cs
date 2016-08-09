using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    /// <summary>
    /// Invaders move along the path towards the base,
    /// They can be shot at by towers and end the game if they reach the base
    /// </summary>
    class Invader
    {
        /// <summary>
        /// A copy of the path along with this invader's progress along it
        /// </summary>
        private readonly Path _path;
        private int _pathStep = 0;


        /// <summary>
        /// Default invader constructor
        /// </summary>
        /// <param name="path"> Copy of the path for the invader to follow </param>
        public Invader(Path path)
        {
            _path = path;
        }


        /// <summary>
        /// Invader hitpoints, defaults to 2
        /// </summary>
        public int HitPoints { get; private set; } = 2;

        /// <summary>
        /// Auto location based on this invader's path step
        /// </summary>
        public MapLocation Location => _path.GetLocationAt(_pathStep);

        /// <summary>
        /// True if invader is on base and is not destroyed, else false
        /// </summary>
        public bool HasScored => _pathStep >= _path.Length && !IsDestroyed;

        /// <summary>
        /// True if invader's hitpoints less than or equal to 0, else false
        /// </summary>
        public bool IsDestroyed => HitPoints <= 0;

        /// <summary>
        /// True if invader hasn't scored and isn't destroyed
        /// </summary>
        public bool IsActive => !(HasScored || IsDestroyed);


        /// <summary>
        /// Progresses invader along the path
        /// </summary>
        public void Move() => _pathStep++;

        /// <summary>
        /// Decrement invader's hitpoints when hit by tower
        /// </summary>
        /// <param name="damage"> Int amount to decrement hitpoints by </param>
        public void TakeDamage(int damage) => HitPoints -= damage;
    }
}
