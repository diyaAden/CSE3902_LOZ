using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class SwordWeaponSprite : BasicItem
    {
        private int direction;

        public SwordWeaponSprite(Texture2D itemSpriteSheet, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            timerLimit = 50;
            switch (direction)
            {
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
    }
}
