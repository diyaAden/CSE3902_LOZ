using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class MagicBoomerangItemSprite : BasicItem
    {
        private const int xPos = 80, yPos = 0, width = 5, height = 8;
        private const string itemName = "MagicBoomerang";

        public MagicBoomerangItemSprite(Texture2D itemSpriteSheet)
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
