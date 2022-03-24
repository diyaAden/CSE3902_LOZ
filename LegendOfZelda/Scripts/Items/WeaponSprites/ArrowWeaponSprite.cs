using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class ArrowWeaponSprite : BasicItem
    {
        private readonly int direction;
        private const int speed = 2, itemTimeLimit = 50, length = 16, width = 5;
        private const int xPosS = 46, yPosS = 16, xPosN = 52, yPosN = 0, xPosW = 14, yPosW = 6, xPosE = 30, yPosE = 0;

        public ArrowWeaponSprite(Texture2D itemSpriteSheet, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            timerLimit = itemTimeLimit;
            switch (direction)
            {
                case 0:
                    animationFrames.Add(new Rectangle(xPosS, yPosS, width, length));
                    break;
                case 1:
                    animationFrames.Add(new Rectangle(xPosN, yPosN, width, length));
                    break;
                case 2:
                    animationFrames.Add(new Rectangle(xPosW, yPosW, length, width));
                    break;
                default:
                    animationFrames.Add(new Rectangle(xPosE, yPosE, length, width));
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