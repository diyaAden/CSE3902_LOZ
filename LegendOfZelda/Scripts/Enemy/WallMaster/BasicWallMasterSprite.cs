using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Enemy.WallMaster.Sprite
{
    class BasicWallMasterSprite : Enemy
    {

        private int animationTimer = 0, currentFrame = 0, direction, timeUntilDirectionChange, movementTimer = 0;
        private readonly float moveSpeed = 0.5f;
        private readonly List<Rectangle> animationFrames = new List<Rectangle>();
        private readonly Random rnd = new Random();

        public BasicWallMasterSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(16, 0, 16, 16));
            MoveSpeed = moveSpeed;
        }
        private Vector2 Move(int direction)
        {
            return direction switch
            {
                0 => new Vector2(position.X, position.Y + moveSpeed),
                1 => new Vector2(position.X, position.Y - moveSpeed),
                2 => new Vector2(position.X - moveSpeed, position.Y),
                _ => new Vector2(position.X + moveSpeed, position.Y),
            };
        }
        public override void Update()
        {
            position = Move(direction);
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
        public override Rectangle ObjectBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}

