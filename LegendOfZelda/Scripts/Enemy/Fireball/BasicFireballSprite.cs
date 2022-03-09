using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy.Fireball.Sprite
{
    class BasicFireballSprite : Enemy
    {

        private int animationTimer = 0, moveSpeed = 1, moveDirection;

        public BasicFireballSprite(Texture2D itemSpriteSheet, int direction, Vector2 position)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 8, 10));
            animationFrames.Add(new Rectangle(8, 0, 8, 10));
            animationFrames.Add(new Rectangle(16, 0, 8, 10));
            animationFrames.Add(new Rectangle(24, 0, 8, 10));
            moveDirection = direction;
            MoveSpeed = moveSpeed;
            pos = position;
        }

        public override void Update()
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            position = new Vector2(position.X - moveSpeed, position.Y + moveSpeed * moveDirection);

        }
        public override Rectangle ObjectBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
        }
    }
}

