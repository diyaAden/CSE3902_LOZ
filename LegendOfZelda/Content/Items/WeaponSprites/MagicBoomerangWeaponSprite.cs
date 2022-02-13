using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class MagicBoomerangWeaponSprite : BasicItem
    {
        
        public MagicBoomerangWeaponSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(129, 19, 5, 8));
        }

        public override void Update()
        {
            
        }
    }
}
