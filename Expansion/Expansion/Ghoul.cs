using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion
{
    class Ghoul : Enemy, ISpriteSize
    {
        public Ghoul(Game game, Point location, int hitPoints, Size spriteSize)
            : base(game, location, hitPoints, spriteSize)
        {
        }

        public override void Move(Random random)
        {
            if (random.Next(1, 3) != 1)
            {
                location = Move(FindplayerDirection(game.playerLocation), game.Boundaries);
            }
            if (NearPlayer())
            {
                game.HitPlayer(4, random);
            }
        }
    }
}
