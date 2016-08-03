using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Console
{
    class Level
    {
        // Fields
        private readonly Invader[] _invaders;


        // Constructor
        public Level(Invader[] invaders, Tower[] Towers)
        {
            _invaders = invaders;
            this.Towers = Towers;
        }


        // Properties
        public Tower[] Towers { get; private set; }
        

        // Methods
        // Returns True if all invaders destroyed and none have scored, else returns false
        public bool Play()
        {
            int remainingInvaders = _invaders.Length;

            while (remainingInvaders > 0)
            {
                foreach (Tower tower in Towers)
                {
                    tower.DamageInvaders(_invaders);
                }

                remainingInvaders = 0;
                foreach (Invader invader in _invaders)
                {
                    if (invader.IsActive)
                    {
                        invader.Move();

                        if (invader.HasScored)
                        {
                            return false;
                        }

                        remainingInvaders++;
                    }
                }
            }
            return true;
        }
    }
}
