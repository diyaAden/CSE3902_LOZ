﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.Sprite
{
    class RightWalkLinkSprite : ISprite
    {
        private Vector2 Pos;
        public Vector2 Position
        {
            get { return Pos; }
            set { Pos = value; }
        }

        public Texture2D Texture { get; set; }

        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public RightWalkLinkSprite(Texture2D texture, Vector2 Position)
        {
            Texture = texture;
            Rows = 1;
            Columns = 2;
            currentFrame = 0;
            totalFrames = Rows * Columns;

            this.Position = Position;
        }
        public void Update()
        {
            Pos.X = Pos.X + 3;
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

