using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class ArrowItemSprite : BasicItem
    {
        
        public ArrowItemSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(52, 0, 5, 16));
        }

        public override void Update()
        {
            
        }
    }
}
