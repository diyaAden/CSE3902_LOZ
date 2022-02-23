using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class WoodBoomerangItemSprite : BasicItem
    {
        
        public WoodBoomerangItemSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(74, 0, 5, 8));
        }

        public override void Update()
        {
            
        }
    }
}
