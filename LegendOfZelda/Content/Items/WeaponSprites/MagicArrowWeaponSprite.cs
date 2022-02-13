using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class MagicArrowWeaponSprite : BasicItem
    {
        
        public MagicArrowWeaponSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(154, 16, 5, 16));
        }

        public override void Update()
        {
            
        }
    }
}
