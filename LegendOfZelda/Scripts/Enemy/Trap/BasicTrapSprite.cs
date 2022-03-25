﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Enemy.Trap.Sprite
{
    class BasicTrapSprite : Enemy
    {
        enum MovingState { READY, ATTACKING, RETREATING }
        private MovingState currentState = MovingState.READY;
        private int direction, attackingTimer = 0, waitTimeLimit, waitingTimer = 0;
        private bool originSet = false;
        private Vector2 originalPosition;
        private readonly Vector2 permittedMoveDist = new Vector2(80, 40);
        private readonly Random rnd = new Random();
        private const int attackSpeed = 2, retreatSpeed = 1, attackingTimeLimit = 45;

        public override Vector2 position {
            get { return pos; }
            set {
                pos = value;
                if (!originSet) {
                    originSet = true;
                    originalPosition = value;
                }
            }
        }
        public BasicTrapSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            direction = rnd.Next(0, 4);
            waitTimeLimit = rnd.Next(120, 181);
            MoveSpeed = retreatSpeed;
        }
        private Vector2 Advance(int direction, int scale)
        {
            return direction switch
            {
                0 => new Vector2(position.X, position.Y + attackSpeed * scale),
                1 => new Vector2(position.X, position.Y - attackSpeed * scale),
                2 => new Vector2(position.X - attackSpeed * scale, position.Y),
                _ => new Vector2(position.X + attackSpeed * scale, position.Y),
            };
        }
        private Vector2 BackTrack(int direction, int scale)
        {
            return direction switch
            {
                0 => new Vector2(position.X, position.Y - retreatSpeed * scale),
                1 => new Vector2(position.X, position.Y + retreatSpeed * scale),
                2 => new Vector2(position.X + retreatSpeed * scale, position.Y),
                _ => new Vector2(position.X - retreatSpeed * scale, position.Y),
            };
        }
        private void Attack(int scale)
        {
            position = Advance(direction, scale);
            if (++attackingTimer >= attackingTimeLimit)
            {
                currentState = MovingState.RETREATING;
                attackingTimer = 0;
                waitTimeLimit = rnd.Next(45, 76);
            }
        }
        private void Retreat(int scale)
        {
            position = BackTrack(direction, scale);
            if (position.X == originalPosition.X && position.Y == originalPosition.Y)
            {
                currentState = MovingState.READY;
                direction = rnd.Next(0, 4);
            }
        }
        public void DetectDirection(Vector2 linkPosition, int scale)
        {
            //detect if start moving and which direction
        }
        public override void Update(Vector2 linkPosition, int scale)
        {
            if (currentState == MovingState.ATTACKING) Attack(scale);
            else if (currentState == MovingState.RETREATING) Retreat(scale);
            else
            {
                //insert call to DetectDirection here
                if (++waitingTimer >= waitTimeLimit)
                {
                    waitingTimer = 0;
                    currentState = MovingState.ATTACKING;
                }
            }
        }
    }
}