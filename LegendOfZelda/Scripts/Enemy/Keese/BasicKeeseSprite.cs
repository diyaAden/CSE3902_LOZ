using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
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
            Health = 1;
        }
        private Vector2 Move(int direction, int scale, Vector2 screenOffset)
        {
            return direction switch
            {
                0 => MovesPastWallsTest(screenOffset, new Vector2(position.X, position.Y + moveSpeed * scale), scale),
                1 => MovesPastWallsTest(screenOffset, new Vector2(position.X, position.Y - moveSpeed * scale), scale),
                2 => MovesPastWallsTest(screenOffset, new Vector2(position.X - moveSpeed * scale, position.Y), scale),
                3 => MovesPastWallsTest(screenOffset, new Vector2(position.X + moveSpeed * scale, position.Y), scale),
                4 => MovesPastWallsTest(screenOffset, new Vector2(position.X + moveSpeed * scale, position.Y + moveSpeed * scale), scale),
                5 => MovesPastWallsTest(screenOffset, new Vector2(position.X + moveSpeed * scale, position.Y - moveSpeed * scale), scale),
                6 => MovesPastWallsTest(screenOffset, new Vector2(position.X - moveSpeed * scale, position.Y + moveSpeed * scale), scale),
                _ => MovesPastWallsTest(screenOffset, new Vector2(position.X - moveSpeed * scale, position.Y - moveSpeed * scale), scale),
            };
        }
        public override void HandleBlockCollision(IGameObject block, ICollision side, int scale) { }
        public override void Update(int scale, Vector2 screenOffset)
        {
            if (hurtCooldown == 0) position = Move(direction, scale, screenOffset);
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
            base.Update(scale, screenOffset);
        }
    }
}

