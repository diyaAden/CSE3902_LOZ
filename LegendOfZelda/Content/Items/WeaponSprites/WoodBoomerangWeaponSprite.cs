using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class WoodBoomerangWeaponSprite : BasicBoomerangWeapon
    {
        private const float startSpeed = 4f;
        private const float accel = 0.1f;

        public WoodBoomerangWeaponSprite(Texture2D itemSpriteSheet, int facing)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(74, 0, 5, 8));
            direction = facing;
            rotationOrigin = new Vector2(animationFrames[0].Width / 2.0f, animationFrames[0].Height / 2.0f);
            speed = new Vector2(startSpeed, startSpeed);
            acceleration = accel;
        }
    }
}
