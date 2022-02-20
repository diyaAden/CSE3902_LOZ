using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class SwordWeaponSprite : BasicItem
    {
        private int direction;
        private int speed = 2;

        public SwordWeaponSprite(Texture2D itemSpriteSheet, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            timerLimit = 45;
            switch (direction)
            {
                //add the second animation frame to each case
                case 0:
                    animationFrames.Add(new Rectangle(0, 16, 7, 16));
                    break;
                case 1:
                    animationFrames.Add(new Rectangle(7, 0, 7, 16));
                    break;
                case 2:
                    animationFrames.Add(new Rectangle(14, 18, 16, 7));
                    break;
                default:
                    animationFrames.Add(new Rectangle(30, 11, 16, 7));
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
