using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class HeartContainerSprite : BasicItem
    {
        
        public HeartContainerSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(48, 0, 13, 13));
        }

        public override void Update()
        {
            
        }
    }
}
