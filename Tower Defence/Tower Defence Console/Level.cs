using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    /// <summary>
    /// Contains invaders and towers for game to be played,
    /// Has method to calculate if player or invaders win
    /// </summary>
    class Level
    {
        /// <summary>
        /// List of all invaders on level
        /// </summary>
        private readonly Invader[] _invaders;


        /// <summary>
        /// The default level constructor
        /// </summary>
        /// <param name="invaders"> Set all invaders on level </param>
        /// <param name="Towers"> Set all towers on level </param>
        public Level(Invader[] invaders, Tower[] Towers)
        {
            _invaders = invaders;
            this.Towers = Towers;
        }


        /// <summary>
        /// Towers on level, can be publicly gotten
        /// </summary>
        public Tower[] Towers { get; private set; }


        /// <summary>
        /// Calculates results of play based on initial setup
        /// </summary>
        /// <returns> True if all invaders destroyed and none have scored, else false </returns>
        public bool Play()
        {
            int remainingInvaders = _invaders.Length;

            while (remainingInvaders > 0)
            {
                // Towers get to attack invaders
                foreach (Tower tower in Towers)
                {
                    tower.DamageInvaders(_invaders);
                }

                remainingInvaders = 0;
                foreach (Invader invader in _invaders)
                {
                    if (invader.IsActive)
                    {
                        // Invaders get to move
                        invader.Move();

                        // Check if invader has scored
                        if (invader.HasScored)
                        {
                            return false;
                        }

                        // Increment invaders if still active to continue loop
                        remainingInvaders++;
                    }
                }
            }
            return true;
        }
    }
}
