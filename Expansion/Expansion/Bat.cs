﻿using System;
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
        public Bat(Game game, Point location, int hitPoints, Size spriteSize)
            : base(game, location, hitPoints, spriteSize)
        {
        }

        public override void Move(Random random)
        {

            if (random.Next(1,2) == 1)
            {
                location = Move(FindplayerDirection(game.playerLocation), game.Boundaries);
            }
            else
            {
                location = Move((Direction)random.Next(1, 4), game.Boundaries);
            }

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
