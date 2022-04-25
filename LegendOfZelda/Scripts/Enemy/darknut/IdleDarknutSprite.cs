using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy
{
    class IdleDarknutSprite : Enemy
    {

        private int animationTimer = 0;

        public IdleDarknutSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
        }

        public override void Update(int scale, Vector2 screenOffset)
        {
            if (++animationTimer > 2)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}

