using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class FairySprite : BasicItem
    {
        private int animationTimer = 0;
        private float straightMove = 1.0f;
        private float diagonalMove = 1.0f / 1.4142f;
        private Vector2 moveSpeed;
        Random rnd = new Random();

        private void SetMoveDirection()
        {
            int num = rnd.Next(8);
            switch (num)
            {
                case 0:
                    moveSpeed = new Vector2(0, straightMove);
                    break;
                case 1:
                    moveSpeed = new Vector2(diagonalMove, diagonalMove);
                    break;
                case 2:
                    moveSpeed = new Vector2(straightMove, 0);
                    break;
                case 3:
                    moveSpeed = new Vector2(diagonalMove, -diagonalMove);
                    break;
                case 4:
                    moveSpeed = new Vector2(0, -straightMove);
                    break;
                case 5:
                    moveSpeed = new Vector2(-diagonalMove, -diagonalMove);
                    break;
                case 6:
                    moveSpeed = new Vector2(-straightMove, 0);
                    break;
                default:
                    moveSpeed = new Vector2(-diagonalMove, diagonalMove);
                    break;
            }
        }
        
        public FairySprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(0, 0, 8, 16));
            animationFrames.Add(new Rectangle(9, 0, 8, 16));
            SetMoveDirection();

        }

        public override void Update()
        {
            if (++animationTimer % 8 == 0)
            {
                currentFrame = ++currentFrame % animationFrames.Count;
                if (animationTimer % 32 == 0)
                {
                    animationTimer = 0;
                    SetMoveDirection();
                }
            }
            pos.X += moveSpeed.X;
            pos.Y += moveSpeed.Y;
        }
    }
}
