﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Fireball.Sprite
{
     class BasicFireballSprite : Enemy
    {

        private int animationTimer = 0, currentFrame = 0, moveSpeed = 1, moveDirection;
        private List<Rectangle> animationFrames = new List<Rectangle>();

        public BasicFireballSprite(Texture2D itemSpriteSheet, int direction, Vector2 position)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 8, 10));
            animationFrames.Add(new Rectangle(8, 0, 8, 10));
            animationFrames.Add(new Rectangle(16, 0, 8, 10));
            animationFrames.Add(new Rectangle(24, 0, 8, 10));
            moveDirection = direction;
            pos = position;
        }

        public override void Update()
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            pos = new Vector2(pos.X - moveSpeed, pos.Y + moveSpeed * moveDirection);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}

