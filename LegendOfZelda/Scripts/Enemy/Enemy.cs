using LegendOfZelda.Scripts.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Enemy
{
    public abstract class Enemy : IEnemy
    {
        protected Texture2D spriteSheet;
        protected Rectangle sourceRect;
        protected Vector2 pos = new Vector2(400, 400);
        public Vector2 position { get { return pos; } set { pos = value; } }

        public virtual Texture2D Texture { get; set; }

        protected virtual int Rows { get; set; }
        protected virtual int Columns { get; set; }
        protected virtual int CurrentFrame { get; set; }
        protected virtual int TotalFrames { get; set; }

        public virtual void Attack() { }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)pos.X, (int)pos.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
