using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy.Explosion.Sprite
{
    class BasicExplosionSprite : Enemy
    {
        private int animationTimer = 0;
        private readonly int moveSpeed = 1;
        public BasicExplosionSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 15, 16));
            animationFrames.Add(new Rectangle(16, 0, 15, 16));
            animationFrames.Add(new Rectangle(32, 0, 15, 16));
            animationFrames.Add(new Rectangle(48, 0, 15, 16));
            MoveSpeed = moveSpeed;
        }

        public override void Update(int scale)
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}

