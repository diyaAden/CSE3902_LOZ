using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.WeaponSprites
{
    public class SwordWeaponSprite : BasicItem
    {
        private int currentSpeed = 0;
        private bool swordOut = false;
        private readonly int direction;
        private const int swordSpeed = 5, delayUntilSwordSpawn = 30, timePerFrame = 3, itemTimeLimit = 60;
        private const int xPosS1 = 0, yPosS1 = 16, xPosS2 = 0, yPosS2 = 0, widthS = 7, heightS = 16;
        private const int xPosN1 = 7, yPosN1 = 0, xPosN2 = 7, yPosN2 = 16, widthN = 7, heightN = 16;
        private const int xPosW1 = 14, yPosW1 = 18, xPosW2 = 30, yPosW2 = 18, widthW = 16, heightW = 7;
        private const int xPosE1 = 30, yPosE1 = 11, xPosE2 = 14, yPosE2 = 11, widthE = 16, heightE = 7;

        public SwordWeaponSprite(Texture2D itemSpriteSheet, int movingDirection)
        {
            spriteSheet = itemSpriteSheet;
            direction = movingDirection;
            timerLimit = itemTimeLimit;
            animationFrames.Add(new Rectangle());
            animationTimer = 0;
        }
        private void SpawnSword()
        {
            animationFrames.Clear();
            SoundController.Instance.PlaySwordBeamSound();
            switch (direction)
            {
                case 0:
                    animationFrames.Add(new Rectangle(xPosS1, yPosS1, widthS, heightS));
                    animationFrames.Add(new Rectangle(xPosS2, yPosS2, widthS, heightS));
                    break;
                case 1:
                    animationFrames.Add(new Rectangle(xPosN1, yPosN1, widthN, heightN));
                    animationFrames.Add(new Rectangle(xPosN2, yPosN2, widthN, heightN));
                    break;
                case 2:
                    animationFrames.Add(new Rectangle(xPosW1, yPosW1, widthW, heightW));
                    animationFrames.Add(new Rectangle(xPosW2, yPosW2, widthW, heightW));
                    break;
                default:
                    animationFrames.Add(new Rectangle(xPosE1, yPosE1, widthE, heightE));
                    animationFrames.Add(new Rectangle(xPosE2, yPosE2, widthE, heightE));
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
        public override void Update()
        {
            if (swordOut) MoveSword();

            if (++animationTimer % timePerFrame == 0) currentFrame = ++currentFrame % animationFrames.Count;

            if (animationTimer == delayUntilSwordSpawn && !swordOut) SpawnSword();
        }
    }
}
