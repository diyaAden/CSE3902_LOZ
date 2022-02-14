using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class BombWeaponSprite : BasicItem
    {
        public BombWeaponSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(136, 0, 8, 14));
            timerLimit = 90;
        }

        public override void Update()
        {
        }
    }
}
