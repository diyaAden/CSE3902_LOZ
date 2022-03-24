﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class ExplosionSprite : BasicItem
    {
        private const int explosionTimePerFrame = 8;
        private const int xPos1 = 9, xPos2 = 26, xPos3 = 43, yPos = 0, width = 16, height = 16;

        public ExplosionSprite(Texture2D particleSpriteSheet)
        {
            spriteSheet = particleSpriteSheet;
            animationFrames.Add(new Rectangle(xPos1, yPos, width, height));
            animationFrames.Add(new Rectangle(xPos2, yPos, width, height));
            animationFrames.Add(new Rectangle(xPos3, yPos, width, height));
            animationTimer = 0;
            timerLimit = animationFrames.Count * explosionTimePerFrame;
        }

        public override void Update()
        {
            if (++animationTimer > explosionTimePerFrame)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}
