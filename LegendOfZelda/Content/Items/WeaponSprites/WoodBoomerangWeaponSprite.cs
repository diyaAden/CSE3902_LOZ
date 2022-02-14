using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class WoodBoomerangWeaponSprite : BasicItem
    {
        
        public WoodBoomerangWeaponSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(129, 3, 5, 8));
        }

        public override void Update()
        {
            
        }
    }
}
