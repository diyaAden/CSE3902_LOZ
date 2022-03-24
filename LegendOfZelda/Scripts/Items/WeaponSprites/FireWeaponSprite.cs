using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class FireWeaponSprite : BasicItem
    {
        private readonly int direction;
        private const int speed = 1, timePerFrame = 6, timeUntilHalt = 60, itemTimeLimit = 120;
        private const int xPos1 = 0, xPos2 = 17, yPos = 0, width = 16, height = 16;

        public FireWeaponSprite(Texture2D itemSpriteSheet, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(xPos1, yPos, width, height));
            animationFrames.Add(new Rectangle(xPos2, yPos, width, height));
            timerLimit = itemTimeLimit;
        }

        public override void Update()
        {
            if (++animationTimer % timePerFrame == 0)
            {
                currentFrame = ++currentFrame % animationFrames.Count;
            }
            if (animationTimer < timeUntilHalt) {
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
