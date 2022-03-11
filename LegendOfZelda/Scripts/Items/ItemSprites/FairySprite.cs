using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class FairySprite : BasicItem
    {
        private int animationTimer = 0, randomNum;
        private readonly float straightMoveSpeed = 1.0f, diagonalMoveSpeed;
        private Vector2 moveSpeed;
        private readonly Random rnd = new Random();

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
            diagonalMoveSpeed = straightMoveSpeed / 1.4142f;
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 8, 16));
            animationFrames.Add(new Rectangle(9, 0, 8, 16));
            name ="Fairy";
            ComputeMoveDirection();
        }

        public override void Update()
        {
            if (++animationTimer % 8 == 0)
            {
                currentFrame = ++currentFrame % animationFrames.Count;
                if (animationTimer % 32 == 0)
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
