using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class BlueRupeeSprite : BasicItem
    {
        
        public BlueRupeeSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(9, 0, 8, 16));
            name = "BlueRupee";
        }

        public override void Update()
        {
            
        }
    }
}
