using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class TriforcePieceSprite : BasicItem
    {
        private const int xPos1 = 0, xPos2 = 11, yPos = 0, width = 10, height = 10, timePerFrame = 7;
        private const string itemName = "TriforcePiece";

        public TriforcePieceSprite(Texture2D itemSpriteSheet)
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
