using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class RupeeSprite : BasicItem
    {
        private const int xPos1 = 0, xPos2 = 9, yPos = 0, width = 8, height = 16, timePerFrame = 7;
        private const string itemName = "Rupee";

        public RupeeSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(xPos1, yPos, width, height));
            animationFrames.Add(new Rectangle(xPos2, yPos, width, height));
            name = itemName;
            animationTimer = 0;
        }

        public override void Update()
        {
            if (++animationTimer > timePerFrame)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}
