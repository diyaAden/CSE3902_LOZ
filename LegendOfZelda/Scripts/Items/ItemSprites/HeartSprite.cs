using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class HeartSprite : BasicItem
    {
        private const int xPos = 0, yPos1 = 0, yPos2 = 9, width = 7, height = 8, timePerFrame = 7;
        private const string itemName = "Heart";

        public HeartSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(xPos, yPos1, width, height));
            animationFrames.Add(new Rectangle(xPos, yPos2, width, height));
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
