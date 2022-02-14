using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class MagicArrowUpWeaponSprite : BasicItem
    {
        
        public MagicArrowUpWeaponSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(52, 16, 5, 16));
        }

        public override void Update()
        {
            
        }
    }
}
