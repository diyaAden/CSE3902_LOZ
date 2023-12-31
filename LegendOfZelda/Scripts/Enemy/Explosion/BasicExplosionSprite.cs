﻿using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Enemy
{
    class BasicExplosionSprite : Enemy
    {
        private int animationTimer = 0;
        private readonly int moveSpeed = 1;
        public BasicExplosionSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 15, 16));
            animationFrames.Add(new Rectangle(16, 0, 15, 16));
            animationFrames.Add(new Rectangle(32, 0, 15, 16));
            animationFrames.Add(new Rectangle(48, 0, 15, 16));
            MoveSpeed = moveSpeed;
            Health = 1; //actually no health, just set now.
        }
        public override void HandleWeaponCollision(IGameObject weapon, ICollision side) { }

        public override void Update(int scale, Vector2 screenOffset)
        {
            if (++animationTimer > 4)
            {
                animationTimer = 0;
                if (++currentFrame == animationFrames.Count) Health = 0;
                currentFrame %= animationFrames.Count;
            }
        }
    }
}

