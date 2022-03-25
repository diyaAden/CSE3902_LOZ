using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class ArrowNickSprite : BasicItem
    {
        private const int itemTimeLimit = 6, xPos = 0, yPos = 0, width = 7, height = 7;

        public ArrowNickSprite(Texture2D particleSpriteSheet)
        {
            spriteSheet = particleSpriteSheet;
            animationFrames.Add(new Rectangle(xPos, yPos, width, height));
            timerLimit = itemTimeLimit;
        }

        public override void Update()
        {
            
        }
    }
}
