using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.Sprite
{
    class RightIdleLinkSprite: ISprite
    {
        private Vector2 Pos;
        public Vector2 Position { get; set; }

        public Texture2D Texture { get; set; }

        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        private bool movingLeft = true;

        public RightIdleLinkSprite(Texture2D texture, Vector2 Position)
        {
            Texture = texture;
            Rows = 1;
            Columns = 2;
            currentFrame = 0;
            totalFrames = Rows * Columns;

            Pos.X = Position.X;
            Pos.Y = Position.Y;
        }
        public Vector2 getPos()
        {
            return Pos;
        }
        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Pos.X, (int)Pos.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}

