using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Enemy.Gel.Sprite
{
    class BasicGelSprite : Enemy
    {
        private bool attacking = false;
        private int movementTimer = 0, moveDist = 0, direction, timeUntilMove = 0;
        private readonly int moveSpeed = 1, moveDistLimit = 16;
        private readonly Random rnd = new Random();

        public BasicGelSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 8, 9));
            animationFrames.Add(new Rectangle(8, 0, 8, 9));
            direction = rnd.Next(0, 4);
            MoveSpeed = moveSpeed;
        }
        private Vector2 Move(int direction, int scale)
        {
            return direction switch
            {
                0 => MovesPastWallsTest(position, new Vector2(position.X, position.Y + moveSpeed * scale), scale),
                1 => MovesPastWallsTest(position, new Vector2(position.X, position.Y - moveSpeed * scale), scale),
                2 => MovesPastWallsTest(position, new Vector2(position.X - moveSpeed * scale, position.Y), scale),
                _ => MovesPastWallsTest(position, new Vector2(position.X + moveSpeed * scale, position.Y), scale),
            };
        }
        public override void Update(int scale)
        {
            if (attacking)
            {
                position = Move(direction, scale);
                moveDist += moveSpeed * scale;
            } else if (++movementTimer >= timeUntilMove)
            {
                movementTimer = 0;
                timeUntilMove = rnd.Next(30, 121);
                attacking = true;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            if (moveDist >= moveDistLimit * scale)
            {
                attacking = false;
                moveDist = 0;
                direction = rnd.Next(0, 4);
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}