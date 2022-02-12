using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class TriforcePieceSprite : BasicItem
    {
        private int animationTimer = 0;
        
        public TriforcePieceSprite(Texture2D itemSpriteSheet, List<Rectangle> frames)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames = frames;
        }

        public override void Update()
        {
            if (++animationTimer > 7)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}
