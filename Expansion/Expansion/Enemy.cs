﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expansion
{
     abstract class Enemy : Mover, ISpriteSize
    {
        private const int NearPlayerDistance = 25;
        public int  HitPoints { get { return hitPoints; } }
        private int hitPoints;
        
        public bool Dead
        { get
            {
                if (hitPoints <= 0)
                {
                    return true;
                }
                else return false;
            }
        }

        public Size SpriteSize { get; private set; }

        public Enemy(Game game, Point location, int hitPoints, Size spriteSize)
            : base(game, location)
        {
            this.hitPoints = hitPoints;
            SpriteSize = spriteSize;
        }

        public abstract void Move(Random random);

        public void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage);
        }

        protected bool NearPlayer()
        {
            return (Nearby(game.playerLocation, NearPlayerDistance));
        }

        protected Direction FindplayerDirection(Point playerLocation)
        {
            Direction directionToMove;
            if (playerLocation.X > location.X + 10)
            {
                directionToMove = Direction.Right;
            }
            else if (playerLocation.X < location.X - 10)
            {
                directionToMove = Direction.Left;
            }
            else if (playerLocation.Y < location.Y - 10)
            {
                directionToMove = Direction.Up;
            }
            else directionToMove = Direction.Down;
            return directionToMove;
        }
    }
}
