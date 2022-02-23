using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class ExplosionSprite : BasicItem
    {
        private int animationTimer = 0;
        private int explosionTimePerFrame = 8;

        public ExplosionSprite(Texture2D particleSpriteSheet)
        {
            spriteSheet = particleSpriteSheet;
            animationFrames.Add(new Rectangle(9, 0, 16, 16));
            animationFrames.Add(new Rectangle(26, 0, 16, 16));
            animationFrames.Add(new Rectangle(43, 0, 16, 16));
            timerLimit = 3 * explosionTimePerFrame;
        }

        public override void Update()
        {
            if (++animationTimer > explosionTimePerFrame)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}
