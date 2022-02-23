using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class SwordWeaponSprite : BasicItem
    {
        private int direction, currentSpeed = 0, animationTimer = 0;
        private readonly int swordSpeed = 2;
        private bool swordOut = false;

        private void SpawnSword()
        {
            animationFrames.Clear();
            switch (direction)
            {
                case 0:
                    animationFrames.Add(new Rectangle(0, 16, 7, 16));
                    animationFrames.Add(new Rectangle(0, 0, 7, 16));
                    break;
                case 1:
                    animationFrames.Add(new Rectangle(7, 0, 7, 16));
                    animationFrames.Add(new Rectangle(7, 16, 7, 16));
                    break;
                case 2:
                    animationFrames.Add(new Rectangle(14, 18, 16, 7));
                    animationFrames.Add(new Rectangle(30, 18, 16, 7));
                    break;
                default:
                    animationFrames.Add(new Rectangle(30, 11, 16, 7));
                    animationFrames.Add(new Rectangle(14, 11, 16, 7));
                    break;
            }
            swordOut = true;
            currentSpeed = swordSpeed;
        }
        private void MoveSword()
        {
            switch (direction)
            {
                case 1:
                    pos.Y -= currentSpeed;
                    break;
                case 3:
                    pos.X += currentSpeed;
                    break;
                case 0:
                    pos.Y += currentSpeed;
                    break;
                default:
                    pos.X -= currentSpeed;
                    break;
            }
        }
        public SwordWeaponSprite(Texture2D itemSpriteSheet, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            timerLimit = 75;
            animationFrames.Add(new Rectangle());
        }
        public override void Update()
        {
            if (swordOut) MoveSword();

            if (++animationTimer % 3 == 2) currentFrame = ++currentFrame % animationFrames.Count;

            if (animationTimer == 30 && !swordOut) SpawnSword();
        }
    }
}
