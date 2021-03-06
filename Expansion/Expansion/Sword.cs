﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location)
            : base(game, location)
        {
        }

        public override string Name
        {
            get
            {
                return "Długi miecz";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            if (!DamageEnemy(direction, 10, 3, random))
            {
                if (!DamageEnemy(Directions(direction), 10, 3, random))
                {
                    DamageEnemy(CounterDirections(direction), 10, 3, random);
                }
            }
        }
        
    }
}
