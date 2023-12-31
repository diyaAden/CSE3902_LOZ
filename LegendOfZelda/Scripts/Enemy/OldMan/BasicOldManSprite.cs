﻿using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy.Fireball.Sprite
{
    class BasicOldManSprite : Enemy
    {

        private int animationTimer = 0;

        public BasicOldManSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            MoveSpeed = 0;
            Health = 1; //Not find information
        }
        public override void HandleWeaponCollision(IGameObject weapon, ICollision side) { }

        public override void Update(int scale, Vector2 screenOffset)
        {
            if (++animationTimer > 10)
            {
                animationTimer = 0;
                currentFrame = ++currentFrame % animationFrames.Count;
            }
        }
    }
}

