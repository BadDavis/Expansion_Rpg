using System;
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
        {//poprawic bo cos nie gra
            switch (direction)
            {
                case Direction.Up:
                    DamageEnemy(Direction.Up, 10, 3, random);
                    break;
                case Direction.Down:
                    DamageEnemy(Direction.Down, 10, 3, random);
                    break;
                case Direction.Left:
                    DamageEnemy(Direction.Left, 10, 3, random);
                    break;
                case Direction.Right:
                    DamageEnemy(Direction.Right, 10, 3, random);
                    break;
                default:
                    break;
            }
        }
    }
}
