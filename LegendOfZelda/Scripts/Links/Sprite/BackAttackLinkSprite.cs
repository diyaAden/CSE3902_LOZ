﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.Sprite
{
    class BackAttackLinkSprite: BasicLinkSprite
    {
        private const int linkHeightInTexture = 16;
        private Vector2 spritePosition;
        public BackAttackLinkSprite(Texture2D texture, Vector2 Position, bool damageState, int scale)
        {
            Rows = 1;
            Columns = 3;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            Texture = texture;
            Pos = Position;
            Position.Y -= 12 * scale;
            spritePosition = Position;
            checkDamageState = damageState;
            Timer = 2;
        }
        public override void Update()
        {
            if (--Timer == 0 && CurrentFrame != TotalFrames - 1)
            {
                ++CurrentFrame;
                Timer = 2;
            }
        }
        public override Rectangle LinkBox(int scale)
        {
            GetBoxSize();
            return new Rectangle((int)Pos.X, (int)Pos.Y, width * scale, linkHeightInTexture * scale);
        }
        public override void Draw(SpriteBatch spriteBatch, int scale)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            if (checkDamageState == true)
            {
                SpriteColor = Color.Red;
            }
            else
            {
                SpriteColor = Color.White;
            }


            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)spritePosition.X, (int)spritePosition.Y, width * scale, height * scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, SpriteColor);

        }
    }
}

