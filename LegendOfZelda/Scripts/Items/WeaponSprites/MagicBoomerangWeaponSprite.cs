﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class MagicBoomerangWeaponSprite : BasicBoomerangWeapon
    {
        private const float startSpeed = 7f;
        private const float accel = 0.2f;

        public MagicBoomerangWeaponSprite(Texture2D itemSpriteSheet, int facing)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(80, 0, 5, 8));
            direction = facing;
            rotationOrigin = new Vector2(animationFrames[0].Width / 2.0f, animationFrames[0].Height / 2.0f);
            speed = new Vector2(startSpeed, startSpeed);
            acceleration = accel;
        }
    }
}