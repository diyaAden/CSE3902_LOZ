using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class FairySprite : BasicItem
    {
        private int randomNum;
        private Vector2 moveSpeed;
        private readonly float diagonalMoveSpeed;
        private readonly int timeUntilDirectionChange;
        private readonly Random rnd = new Random();
        private const float sqrt2 = 1.4142f, straightMoveSpeed = 1.0f;
        private const int xPos1 = 0, xPos2 = 9, yPos = 0, width = 8, height = 16, timePerFrame = 8;
        private const string itemName = "Fairy";

        private void ComputeMoveDirection()
        {
            randomNum = rnd.Next(8);
            // 0 <= num < 8 : 0 = north and the numbers go around clockwise until 7 = northwest
            bool movingDiagonal = randomNum % 2 == 1;
            bool positiveX = randomNum < 4;
            bool positiveY = randomNum > 2 && randomNum < 6;
            SetMoveDirection(positiveX, positiveY, movingDiagonal);
        }
        private void SetMoveDirection(bool positiveX, bool positiveY, bool diagonalMove)
        {
            int directionX = 1, directionY = 1;
            if (!positiveX) { directionX = -1; }
            if (!positiveY) { directionY = -1; }
            if (randomNum == 0 || randomNum == 4) { directionX = 0; }
            if (randomNum == 2 || randomNum == 6) { directionY = 0; }

            if (diagonalMove) { moveSpeed = new Vector2(diagonalMoveSpeed * directionX, diagonalMoveSpeed * directionY); }
            else { moveSpeed = new Vector2(straightMoveSpeed * directionX, straightMoveSpeed * directionY); }
        }
        
        public FairySprite(Texture2D itemSpriteSheet)
        {
            diagonalMoveSpeed = straightMoveSpeed / sqrt2;
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(xPos1, yPos, width, height));
            animationFrames.Add(new Rectangle(xPos2, yPos, width, height));
            name = itemName;
            animationTimer = 0;
            ComputeMoveDirection();
            timeUntilDirectionChange = timePerFrame * 4;
        }

        public override void Update()
        {
            if (++animationTimer % timePerFrame == 0)
            {
                currentFrame = ++currentFrame % animationFrames.Count;
                if (animationTimer == timeUntilDirectionChange)
                {
                    animationTimer = 0;
                    ComputeMoveDirection();
                }
            }
            pos.X += moveSpeed.X;
            pos.Y += moveSpeed.Y;
        }
    }
}
