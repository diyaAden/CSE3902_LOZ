using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class CompassSprite : BasicItem
    {
        private const int xPos = 62, yPos = 0, width = 11, height = 12;
        private const string itemName = "Compass";

        public CompassSprite(Texture2D itemSpriteSheet)
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
