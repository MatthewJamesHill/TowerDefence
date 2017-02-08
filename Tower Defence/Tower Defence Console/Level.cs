using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Level
    {
        private readonly Invader[] _invaders;

        public Level(Invader[] invaders, Tower[] Towers)
        {
            _invaders = invaders;
            this.Towers = Towers;
        }

        public Tower[] Towers { get; private set; }

        public bool Play()
        {
            int remainingInvaders = _invaders.Length;

            while (remainingInvaders > 0)
            {
                // Towers get to attack invaders
                foreach (Tower tower in Towers)
                {
                    tower.ShootAtInvaders(_invaders);
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
