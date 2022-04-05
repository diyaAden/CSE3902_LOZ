using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Enemy.Stalfos.Sprite
{
    class BasicStalfosSprite : Enemy
    {

        private int animationTimer = 0, direction, timeUntilDirectionChange, movementTimer = 0;
        private readonly int moveSpeed = 1;
        private readonly Random rnd = new Random();

        public BasicStalfosSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(16, 0, 16, 16));
            direction = rnd.Next(0, 4);
            timeUntilDirectionChange = rnd.Next(45, 76);
            MoveSpeed = moveSpeed;
            health = 2;
        }
        private Vector2 Move(int direction, int scale, Vector2 screenOffset)
        {
            return direction switch
            {
                0 => MovesPastWallsTest(screenOffset, new Vector2(position.X, position.Y + moveSpeed * scale), scale),
                1 => MovesPastWallsTest(screenOffset, new Vector2(position.X, position.Y - moveSpeed * scale), scale),
                2 => MovesPastWallsTest(screenOffset, new Vector2(position.X - moveSpeed * scale, position.Y), scale),
                _ => MovesPastWallsTest(screenOffset, new Vector2(position.X + moveSpeed * scale, position.Y), scale),
            };
        }
        public override void Update(int scale, Vector2 screenOffset)
        {
            position = Move(direction, scale, screenOffset);
            if (++movementTimer >= timeUntilDirectionChange)
            {
                movementTimer = 0;
                direction = rnd.Next(0, 4);
                timeUntilDirectionChange = rnd.Next(45, 76);
            }
            if (++animationTimer == 5)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}

