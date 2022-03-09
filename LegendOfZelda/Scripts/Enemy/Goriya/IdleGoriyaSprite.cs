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
    }
}

