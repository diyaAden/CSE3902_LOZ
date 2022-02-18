using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class BombItemSprite : BasicItem
    {
        
        public BombItemSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(39, 0, 8, 14));
        }

        public override void Update()
        {
            
        }
    }
}
