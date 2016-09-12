using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion
{
    class Player : Mover, ISpriteSize
    {
        private Weapon equippedWeapon;
        public int HitPoints { get; private set; }
        private List<Weapon> inventory = new List<Weapon>();

        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                {
                    names.Add(weapon.Name);
                }
                return names;
            }
        }

        public Size SpriteSize
        {
            get;
            private set;
        }

        public Player(Game game, Point location, Size spriteSize)
            : base(game, location)
        {
            HitPoints = 10;
            this.SpriteSize = spriteSize;
        }

        public void Hit(int maxDamage, Random random) //Przeciwnik atakuje gracza
        {
            HitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random) //Gracz leczy rany
        {
            HitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName) // Gracz wybiera broń
        {
            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                {
                    equippedWeapon = weapon;
                }
            }
        }

        public void Move(Direction direction)
        {
            Weapon nearWeapon;
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                //Sprawdz, czy bron jest w pobliżu
                //Jeśli jest jedynym przedmiotem, jest automatycznie wybierana
                if (Nearby(game.playerLocation, 25))
                {

                }
            }
        }

        public bool CheckPotionUsed(string potionName)
        {
            IPotion potion;
            bool potionUsed = true;

            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == potionName && weapon is IPotion)
                {
                    potion = weapon as IPotion;
                    potionUsed = potion.Used;
                }
            }

            return potionUsed;
        }

        public void Attack(Direction direction, Random random)
        {
            Player player;
            //Jeśli gracz ma bron wtedy atakuje
            //Potion użyty znika z eq+
            if (inventory.Contains(equippedWeapon))
            {
                switch (direction)
                {
                    case Direction.Up:
                        game.Attack(Direction.Up, random);
                        break;
                    case Direction.Down:
                        game.Attack(Direction.Down, random);
                        break;
                    case Direction.Left:
                        game.Attack(Direction.Left, random);
                        break;
                    case Direction.Right:
                        game.Attack(Direction.Right, random);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (inventory.Contains(RedPotion) )
                {
                    player.IncreaseHealth(1, random);
                    inventory.Remove(Red);
                }
                if (inventory.Concat(Blue)
                {
                    player.
                    inventory.Remove(Blue);
                }
            }
        }
    }
}
