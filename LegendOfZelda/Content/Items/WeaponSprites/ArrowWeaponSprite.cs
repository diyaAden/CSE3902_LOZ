using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Items.WeaponSprites
{
    public class ArrowWeaponSprite : BasicItem
    {
        private int direction; //1=up, 2=right, 3=down, 4=left
        private int speed = 2;
        
        public ArrowWeaponSprite(Texture2D itemSpriteSheet, Rectangle sourceRect, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(sourceRect);
            direction = movingDirection;
            timerLimit = 20;
        }

        public override void Update()
        {
            switch (direction)
            {
                case 1:
                    pos.Y -= speed;
                    break;
                case 2:
                    pos.X += speed;
                    break;
                case 3:
                    pos.Y += speed;
                    break;
                default:
                    pos.X -= speed;
                    break;
            }
        }
    }
}
