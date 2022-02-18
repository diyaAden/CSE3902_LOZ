using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class MagicBoomerangItemSprite : BasicItem
    {
        
        public MagicBoomerangItemSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(80, 0, 5, 8));
        }

        public override void Update()
        {
            
        }
    }
}
