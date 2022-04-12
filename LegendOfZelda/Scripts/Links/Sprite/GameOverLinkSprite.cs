using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.Sprite
{
    class GameOverLinkSprite: BasicLinkSprite
    {
        private const int linkHeightInTexture = 15;

        public GameOverLinkSprite(Texture2D texture, Vector2 Position)
        {
            Rows = 1;
            Columns = 4;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            Texture = texture;
            Pos = Position;
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
            GetBoxSize();

            if (checkDamageState == true)
            {
                SpriteColor = Color.Red;
            }
            else
            {
                SpriteColor = Color.White;
            }

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = base.LinkBox(scale);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, SpriteColor);

        }
    }
}

