﻿using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Enemy
{
    class BasicFireballSprite : Enemy
    {

        private int animationTimer = 0, moveSpeed = 1, moveDirection, shootingSide;

        public BasicFireballSprite(Texture2D itemSpriteSheet, int direction, int side, Vector2 position)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 8, 10));
            animationFrames.Add(new Rectangle(8, 0, 8, 10));
            animationFrames.Add(new Rectangle(16, 0, 8, 10));
            animationFrames.Add(new Rectangle(24, 0, 8, 10));
            moveDirection = direction;
            shootingSide = side;
            MoveSpeed = moveSpeed;
            pos = position;
            Health = 1;
        }
        public override void HandleWeaponCollision(IGameObject weapon, ICollision side) { }
        public override void HandleBlockCollision(IGameObject block, ICollision side, int scale) { }
        public override void Update(int scale, Vector2 screenOffset)
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            position = new Vector2(position.X - moveSpeed * scale * shootingSide, position.Y + moveSpeed * moveDirection * scale);
            if (position.X <= (screenOffset.X) * scale) Health = 0;
        }
    }
}

