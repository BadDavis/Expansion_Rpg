using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location) 
            : base(game, location)
        {
        }

        public override string Name
        {
            get
            {
                return "Buława";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            if (!DamageEnemy(direction, 20, 6, random))
            {
                Direction nextAttack = CounterDirections(direction);
                for (int i = 0; i < 3; i++)
                {
                    if (DamageEnemy(nextAttack, 20, 6, random))
                    {
                        break;
                    }
                    nextAttack = CounterDirections(direction);
                }
            }
        }
    }
}
