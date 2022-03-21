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
        private Vector2 Move(int direction, int scale)
        {
            return direction switch
            {
                0 => MovesPastWallsTest(position, new Vector2(position.X, position.Y + moveSpeed * scale), scale),
                1 => MovesPastWallsTest(position, new Vector2(position.X, position.Y - moveSpeed * scale), scale),
                2 => MovesPastWallsTest(position, new Vector2(position.X - moveSpeed * scale, position.Y), scale),
                3 => MovesPastWallsTest(position, new Vector2(position.X + moveSpeed * scale, position.Y), scale),
                4 => MovesPastWallsTest(position, new Vector2(position.X + moveSpeed * scale, position.Y + moveSpeed * scale), scale),
                5 => MovesPastWallsTest(position, new Vector2(position.X + moveSpeed * scale, position.Y - moveSpeed * scale), scale),
                6 => MovesPastWallsTest(position, new Vector2(position.X - moveSpeed * scale, position.Y + moveSpeed * scale), scale),
                _ => MovesPastWallsTest(position, new Vector2(position.X - moveSpeed * scale, position.Y - moveSpeed * scale), scale),
            };
        }
        public override void Update(int scale)
        {
            position = Move(direction, scale);
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

