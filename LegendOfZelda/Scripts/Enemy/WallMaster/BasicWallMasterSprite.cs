using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Enemy.WallMaster.Sprite
{
    class BasicWallMasterSprite : Enemy
    {

        private int animationTimer = 0, direction, timeUntilDirectionChange, movementTimer = 0;
        private readonly float moveSpeed = 0.5f;
        private readonly Random rnd = new Random();

        public BasicWallMasterSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(16, 0, 16, 16));
            MoveSpeed = moveSpeed;
        }
        private Vector2 Move(int direction, int scale)
        {
            return direction switch
            {
                0 => new Vector2(position.X, position.Y + moveSpeed * scale),
                1 => new Vector2(position.X, position.Y - moveSpeed * scale),
                2 => new Vector2(position.X - moveSpeed * scale, position.Y),
                _ => new Vector2(position.X + moveSpeed * scale, position.Y),
            };
        }
        public override void Update(int scale)
        {
            position = Move(direction, scale);
            if (++movementTimer >= timeUntilDirectionChange)
            {
                movementTimer = 0;
                direction = rnd.Next(0, 4);
                timeUntilDirectionChange = rnd.Next(60, 121);
            }
            if (++animationTimer > 10)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}

