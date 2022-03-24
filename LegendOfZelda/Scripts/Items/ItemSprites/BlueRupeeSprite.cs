using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class BlueRupeeSprite : BasicItem
    {
        private const int xPos = 9, yPos = 0, width = 8, height = 16;
        private const string itemName = "BlueRupee";

        public BlueRupeeSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(xPos, yPos, width, height));
            name = itemName;
        }

        public override void Update()
        {
            
        }
    }
}
