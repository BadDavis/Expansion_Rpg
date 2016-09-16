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
        private int hitPoints;
        public int HitPoints { get { return hitPoints; } }
        private List<Weapon> inventory = new List<Weapon>();

        public List<string> Weapons
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
            hitPoints = 10;
            this.SpriteSize = spriteSize;
        }

        public void Hit(int maxDamage, Random random) //Przeciwnik atakuje gracza
        {
            hitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random) //Gracz leczy rany
        {
            hitPoints += random.Next(1, health);
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
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                if (Nearby(game.WeaponInRoom.Location, 1))
                {
                    game.WeaponInRoom.PickedUpWeapon();
                    inventory.Add(game.WeaponInRoom);
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
            //Jeśli gracz ma bron wtedy atakuje
            //Potion użyty znika z eq+
            if (inventory.Contains(equippedWeapon))
            {
                equippedWeapon.Attack(direction, random);
            }
        }
    }
}
