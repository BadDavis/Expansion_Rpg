using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion
{
    class Bat : Enemy
    {
        Player player;
        public Bat(Game game, Point location, int hitPoints)
            : base(game, location, 6)
        {
        }

        public override void Move(Random random)
        {
            


            if (NearPlayer())
            {
                while (player.HitPoints >= 1)
                {
                    player.Hit(2, random);
                }
            }
        }
    }
}
