using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Expansion
{
    class Game
    {
        public IEnumerable<Enemy> Enemies { get; private set;}
        public Weapon WeaponInRoom { get; private set; }

        private Player player;
        public Point playerLocation { get { return player.Location; } }
        public int playerHitPoints { get { return player.HitPoints; } }
        public IEnumerable<string> PlayerWeapons { get { return player.Weapons; } }
        private int level = 0;
        public int Level { get { return level; } }

        private Rectangle boundaries;
        public Rectangle Boundaries { get { return boundaries; } }
        public Size PlayerSpriteSize { get { return player.SpriteSize; } }

        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            player = new Player(this, new Point(boundaries.Left + 10, boundaries.Top + 70));
        }

        public void Move(Direction direction, Random random)
        {
            player.Move(direction);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }

        public void Equip(string weaponname)
        {
            player.Equip(weaponname);
        }

        public bool CheckPlayerInventory(string weaponname)
        {
            return player.Weapons.Contains(weaponname);
        }

        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }

        public void Attack(Direction direction, Random random)
        {
            player.Attack(direction, random);
            foreach (Enemy enemy in Enemies)
            {
                enemy.move(random);
            }
        }

        public bool Potion(string potionName)
        {
            return player.CheckPotionUsed(potionName);
        }

        private Point GetRandomLocation(Random random)
        {
            return new Point(boundaries.Left +
                random.Next(boundaries.Right / 10 - boundaries.Left / 10) * 10,
                boundaries.Top +
                random.Next(boundaries.Bottom / 10 - boundaries.Top / 10) * 10);
        }

        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random)));
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;

                case 2:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    WeaponInRoom = new Blue(this, GetRandomLocation(random));
                    break;

                case 3:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random));
                    WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;

                case 4:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random)));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    if (player.Weapons.Contains(Bow))
                    {
                        WeaponInRoom = new Blue(this, GetRandomLocation(random));
                    }
                    else WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;

                case 5:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random)));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    WeaponInRoom = new Red(this, GetRandomLocation(random));
                    break;

                case 6:
                    Enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    break;

                case 7:
                    Enemies.Add(new Bat(this, GetRandomLocation(random)));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    if (!player.Weapon.Contains(Mace))
                    {
                        WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    }
                    else if (!player.Weapons.Contains(Red))
                    {
                        WeaponInRoom = new Red(this, GetRandomLocation(random));
                    }
                    else WeaponInRoom = new BattleAxe(this, GetRandomLocation(random));
                    break;

                default:
                    Application.Exit();
                    break;
            }
        }
    }
}
