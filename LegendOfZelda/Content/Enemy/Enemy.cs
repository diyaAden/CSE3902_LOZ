using LegendOfZelda.Content.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy
{
    class Enemy : IEnemy
    {
        protected Texture2D spriteSheet;
        protected Rectangle sourceRect;
        protected Vector2 pos = new Vector2(400, 100);
        public Vector2 position { get { return pos; } set { pos = value; } }

        public void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width, sourceRect.Height);
            spriteBatch.Draw(spriteSheet, destRect, sourceRect, Color.White);
        }
    }
}
