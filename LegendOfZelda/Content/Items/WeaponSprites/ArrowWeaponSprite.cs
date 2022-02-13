using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class ArrowWeaponSprite : BasicItem
    {
        
        public ArrowWeaponSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(154, 0, 5, 16));
        }

        public override void Update()
        {
            
        }
    }
}
