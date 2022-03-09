﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    public class FireBlockSprite : BasicBlock
    {
        private int animationTimer = 0, currentFrame = 0;
        private List<Rectangle> animationFrames = new List<Rectangle>();
        
        public FireBlockSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(17, 0, 16, 16));
            transparency = 1f;
        }

        public override void Update()
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width * scale, animationFrames[currentFrame].Height * scale);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}
