using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class MapSprite : BasicItem
    {
        
        public MapSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(12, 0, 8, 16));
        }

        public override void Update()
        {
            
        }
    }
}
