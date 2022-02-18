using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class BowSprite : BasicItem
    {
        
        public BowSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(30, 0, 8, 16));
        }

        public override void Update()
        {
            
        }
    }
}
