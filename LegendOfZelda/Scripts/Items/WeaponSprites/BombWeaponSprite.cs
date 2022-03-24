using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class BombWeaponSprite : BasicItem
    {
        private const int itemTimeLimit = 90, xPos = 39, yPos = 0, width = 8, height = 14;

        public BombWeaponSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(xPos, yPos, width, height));
            timerLimit = itemTimeLimit;
        }

        public override void Update()
        {
        }
    }
}
