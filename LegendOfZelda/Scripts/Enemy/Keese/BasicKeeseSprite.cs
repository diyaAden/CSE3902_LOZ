using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Enemy.Keese.Sprite
{
    class BasicKeeseSprite : Enemy
    {

        private int animationTimer = 0, direction, timeUntilDirectionChange, movementTimer = 0;
        private readonly int moveSpeed = 1;
        private readonly Random rnd = new Random();

        public BasicKeeseSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 8));
            animationFrames.Add(new Rectangle(16, 0, 16, 8));
            direction = rnd.Next(0, 8);
            timeUntilDirectionChange = rnd.Next(30, 61);
            MoveSpeed = moveSpeed;
        }
        private Vector2 Move(int direction)
        {
            return direction switch
            {
                0 => new Vector2(position.X, position.Y + moveSpeed),
                1 => new Vector2(position.X, position.Y - moveSpeed),
                2 => new Vector2(position.X - moveSpeed, position.Y),
                3 => new Vector2(position.X + moveSpeed, position.Y),
                4 => new Vector2(position.X + moveSpeed, position.Y + moveSpeed),
                5 => new Vector2(position.X + moveSpeed, position.Y - moveSpeed),
                6 => new Vector2(position.X - moveSpeed, position.Y + moveSpeed),
                _ => new Vector2(position.X - moveSpeed, position.Y - moveSpeed),
            };
        }
        public override void Update()
        {
            position = Move(direction);
            if (++movementTimer >= timeUntilDirectionChange)
            {
                movementTimer = 0;
                direction = rnd.Next(0, 8);
                timeUntilDirectionChange = rnd.Next(30, 61);
            }
            if (++animationTimer == 7)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}

