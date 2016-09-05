using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion
{
    class BattleAxe : Weapon
    {
        public BattleAxe(Game game, Point location) : base(game, location)
        {
        }

        public override string Name
        {
            get
            {
                return "Topór Obosieczny";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, 10, 4, random);
        }
    }
}
