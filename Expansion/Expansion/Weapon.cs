using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion
{
    abstract class Weapon : Mover
    {
        public bool PickedUp
        {
            get
            {
                return pickedUp;
            }
        }

        public Weapon(Game game, Point location) : base(game, location)
        {
            pickedUp = false;
        }

        public void PickedUpWeapon() { pickedUp = true; }
        private bool pickedUp;

        public abstract string Name { get; }

        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            //metoda próbuje znależć przeciwnika w podanym kierunku i odległości
            Point target = game.playerLocation;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (!enemy.Dead && Nearby(target, enemy, direction, radius))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
             // pozniej   target = Move(direction, target, game.Boundaries);
            }
            return false;
        }



        private bool Nearby(Point playerLocation , Enemy enemy, Direction direction, int distance)
        {
            bool isNearby = false;

            Rectangle enemySpriteBoundary = new Rectangle(enemy.Location, enemy.SpriteSize);
            Rectangle playerAtackArea = new Rectangle();

            switch (direction)
            {
                case Direction.Up:
                    playerAtackArea.Location = new Point(playerLocation.X, playerLocation.Y - distance);
                    playerAtackArea.Width = game.PlayerSpriteSize.Width;
                    playerAtackArea.Height = distance;
                    break;
                case Direction.Down:
                    playerAtackArea.Location = new Point(playerLocation.X, playerLocation.Y + game.PlayerSpriteSize.Height);
                    playerAtackArea.Width = game.PlayerSpriteSize.Width;
                    playerAtackArea.Height = distance;
                    break;
                case Direction.Left:
                    playerAtackArea.Location = new Point(playerLocation.X + distance, playerLocation.Y);
                    playerAtackArea.Width = distance;
                    playerAtackArea.Height = game.PlayerSpriteSize.Height;
                    break;
                case Direction.Right:
                    playerAtackArea.Location = new Point(playerLocation.X + game.PlayerSpriteSize.Width, playerLocation.Y);
                    playerAtackArea.Width = distance;
                    playerAtackArea.Height = game.PlayerSpriteSize.Height;
                    break;
                default:
                    break;
            }

            if (playerAtackArea.IntersectsWith(enemySpriteBoundary))
            {
                isNearby = true;
            }
            return isNearby;
        }

        protected Direction Directions(Direction direction)
        {
            Direction directions = direction;

            switch (direction)
            {
                case Direction.Up:
                    direction = Direction.Right;
                    break;
                case Direction.Down:
                    direction = Direction.Left;
                    break;
                case Direction.Left:
                    direction = Direction.Up;
                    break;
                case Direction.Right:
                    direction = Direction.Down;
                    break;
                default:
                    break;
            }
            return direction;
        }

        public Direction CounterDirections(Direction direction)
        {
            Direction counterDirection = direction;

            switch (direction)
            {
                case Direction.Up:
                    counterDirection = Direction.Right;
                    break;
                case Direction.Down:
                    counterDirection = Direction.Left;
                    break;
                case Direction.Left:
                    counterDirection = Direction.Up;
                    break;
                case Direction.Right:
                    counterDirection = Direction.Down;
                    break;
                default:
                    break;
            }
            return counterDirection;
        }
    }

}
