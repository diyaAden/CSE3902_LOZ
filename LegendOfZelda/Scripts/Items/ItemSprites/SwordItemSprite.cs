using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class SwordItemSprite : BasicItem
    {
        private const int xPos = 104, yPos = 0, width = 3, height = 16;
        private const string itemName = "Sword";

        public SwordItemSprite(Texture2D itemSpriteSheet)
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
