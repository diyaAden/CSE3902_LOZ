using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class MagicArrowWeaponSprite : BasicItem
    {
        private readonly int direction;
        private const int speed = 6;

        public MagicArrowWeaponSprite(Texture2D itemSpriteSheet, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            timerLimit = 50;
            switch (direction)
            {
                case 0:
                    animationFrames.Add(new Rectangle(46, 0, 5, 16));
                    break;
                case 1:
                    animationFrames.Add(new Rectangle(52, 16, 5, 16));
                    break;
                case 2:
                    animationFrames.Add(new Rectangle(30, 6, 16, 5));
                    break;
                default:
                    animationFrames.Add(new Rectangle(14, 0, 16, 5));
                    break;
            }
        }

        public override void Update()
        {
            switch (direction)
            {
                case 1:
                    pos.Y -= speed;
                    break;
                case 3:
                    pos.X += speed;
                    break;
                case 0:
                    pos.Y += speed;
                    break;
                default:
                    pos.X -= speed;
                    break;
            }
        }
    }
}