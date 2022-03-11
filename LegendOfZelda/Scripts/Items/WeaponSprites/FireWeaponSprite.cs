using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class FireWeaponSprite : BasicItem
    {
        private readonly int speed = 1, direction;

        public FireWeaponSprite(Texture2D itemSpriteSheet, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 16, 16));
            animationFrames.Add(new Rectangle(17, 0, 16, 16));
            animationTimer = 1;
            timerLimit = 120;
        }

        public override void Update()
        {
            if (++animationTimer % 6 == 0)
            {
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            if (animationTimer < 60) {
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
}
