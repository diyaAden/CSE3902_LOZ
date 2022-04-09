using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class SwordWeaponSprite : BasicItem
    {
        private readonly int direction;
        private const int itemTimeLimit = 60, preBeamHitboxSizeLong = 11, preBeamHitboxSizeShort = 7;

        public SwordWeaponSprite(Texture2D itemSpriteSheet, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            timerLimit = itemTimeLimit;
            animationFrames.Add(new Rectangle());
            animationTimer = 0;
        }
        public override Rectangle ObjectBox(int scale)
        {
            if (direction == 0 || direction == 1)
                return new Rectangle((int)pos.X, (int)pos.Y, preBeamHitboxSizeShort * scale, preBeamHitboxSizeLong * scale);
            else
                return new Rectangle((int)pos.X, (int)pos.Y, preBeamHitboxSizeLong * scale, preBeamHitboxSizeShort * scale);
        }
        public override void Update() { }
    }
}
