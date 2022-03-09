using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy.Goriya.Sprite
{
    class IdleGoriyaSprite : Enemy
    {

        private int animationTimer = 0;

        public IdleGoriyaSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
        }

        public override void Update()
        {
            if (++animationTimer > 2)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }

        }
        public override Rectangle ObjectBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
        }
    }
}

