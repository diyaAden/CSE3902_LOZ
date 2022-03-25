using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class MagicBoomerangWeaponSprite : BasicBoomerangWeapon
    {
        private const float startSpeed = 7f, accel = 0.2f;
        private const int xPos = 80, yPos = 0, width = 5, height = 8;

        public MagicBoomerangWeaponSprite(Texture2D itemSpriteSheet, int facing)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(xPos, yPos, width, height));
            direction = facing;
            rotationOrigin = new Vector2(animationFrames[0].Width / 2.0f, animationFrames[0].Height / 2.0f);
            speed = new Vector2(startSpeed, startSpeed);
            acceleration = accel;
        }
    }
}
