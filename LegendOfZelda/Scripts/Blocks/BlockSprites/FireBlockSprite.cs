using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    public class FireBlockSprite : BasicBlock
    {
        private const int xPos1 = 0, xPos2 = 17, yPos = 0, width = 16, height = 16, timePerFrame = 4;
        private readonly List<Rectangle> animationFrames = new List<Rectangle>();
        private int animationTimer = 0, currentFrame = 0;
        
        public FireBlockSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(xPos1, yPos, width, height));
            animationFrames.Add(new Rectangle(xPos2, yPos, width, height));
        }

        public override void Update()
        {
            if (++animationTimer > timePerFrame)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, animationFrames[currentFrame].Width * scale, animationFrames[currentFrame].Height * scale);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}
