using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class KeySprite : BasicItem
    {
        
        public KeySprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(21, 0, 8, 16));
        }

        public override void Update()
        {
            
        }
    }
}
