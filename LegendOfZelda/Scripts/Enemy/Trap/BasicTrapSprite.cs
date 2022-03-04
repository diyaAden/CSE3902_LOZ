using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Enemy.Trap.Sprite
{
    class BasicTrapSprite : Enemy
    {
        private int direction, attackingTimer = 0, waitTimeLimit, waitingTimer = 0;
        private bool attacking = false, retreating = false, originSet = false;
        private Vector2 originalPosition;
        private readonly int currentFrame = 0, attackSpeed = 2, retreatSpeed = 1, attackingTimeLimit = 45;
        private readonly List<Rectangle> animationFrames = new List<Rectangle>();
        private readonly Random rnd = new Random();

        public override Vector2 position
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
                if (!originSet)
                {
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
        }
        private Vector2 Advance(int direction)
        {
            return direction switch
            {
                0 => new Vector2(position.X, position.Y + attackSpeed),
                1 => new Vector2(position.X, position.Y - attackSpeed),
                2 => new Vector2(position.X - attackSpeed, position.Y),
                _ => new Vector2(position.X + attackSpeed, position.Y),
            };
        }
        private Vector2 Retreat(int direction)
        {
            return direction switch
            {
                0 => new Vector2(position.X, position.Y - retreatSpeed),
                1 => new Vector2(position.X, position.Y + retreatSpeed),
                2 => new Vector2(position.X + retreatSpeed, position.Y),
                _ => new Vector2(position.X - retreatSpeed, position.Y),
            };
        }
        public override void Update()
        {
            if (attacking)
            {
                position = Advance(direction);
                if (++attackingTimer >= attackingTimeLimit)
                {
                    attacking = false;
                    retreating = true;
                    attackingTimer = 0;
                    waitTimeLimit = rnd.Next(45, 76);
                }
            }
            else if (retreating)
            {
                position = Retreat(direction);
                if (position.X == originalPosition.X && position.Y == originalPosition.Y)
                {
                    retreating = false;
                    direction = rnd.Next(0, 4);
                }
            }
            else
            {
                if (++waitingTimer >= waitTimeLimit)
                {
                    waitingTimer = 0;
                    attacking = true;
                }
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}