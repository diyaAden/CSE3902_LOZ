using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class BlueRupeeSprite : BasicItem
    {
        
        public BlueRupeeSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(72, 16, 8, 16));
        }

        public override void Update()
        {
            
        }
    }
}
