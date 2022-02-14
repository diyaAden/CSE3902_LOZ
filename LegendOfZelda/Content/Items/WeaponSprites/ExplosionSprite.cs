using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class ExplosionSprite : BasicItem
    {
        
        public ExplosionSprite(Texture2D particleSpriteSheet, Rectangle sourceRect)
        {
            spriteSheet = particleSpriteSheet;
            animationFrames.Add(sourceRect);
            timerLimit = 20;
        }

        public override void Update()
        {
            
        }
    }
}
