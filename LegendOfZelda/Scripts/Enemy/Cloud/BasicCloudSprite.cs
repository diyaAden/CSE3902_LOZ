﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy.Cloud.Sprite
{
    class BasicCloudSprite : Enemy
    {

        private int animationTimer = 0;
        private int moveSpeed = 1;

        public BasicCloudSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(16, 0, 16, 16));
            animationFrames.Add(new Rectangle(32, 0, 16, 16));
            animationFrames.Add(new Rectangle(48, 0, 16, 16));
            MoveSpeed = moveSpeed;
        }

        public override void Update(int scale)
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }

        }
    }
}

