using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class ArrowNickSprite : BasicItem
    {

        public ArrowNickSprite(Texture2D particleSpriteSheet)
        {
            spriteSheet = particleSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 7, 7));
            timerLimit = 6;
        }

        public override void Update()
        {
            
        }
    }
}
