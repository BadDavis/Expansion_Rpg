using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location, int hitPoints)
            : base(game, location, 8)
        {
        }

        public override void Move(Random random)
        {
            switch (random)
            {
                case 1:


                default:
                    break;
            }
        }
    }
}
