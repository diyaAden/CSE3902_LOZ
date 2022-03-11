﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Items
{
    public abstract class BasicItem : IItem
    {
        protected Texture2D spriteSheet;
        protected List<Rectangle> animationFrames = new List<Rectangle>();
        protected int currentFrame = 0;
        protected Vector2 pos = new Vector2(400, 200);
        protected int timerLimit = -1;
        public int TimeLimit => timerLimit;
        public virtual Vector2 Position { get { return pos; } set { pos = value; } }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        protected string name;

        public virtual void Update() { }

        public virtual void Update(Vector2 linkPosition) { }

        public virtual void PickItem(Vector2 linkPosition)
        {
            pos = new Vector2(linkPosition.X + 10, linkPosition.Y - 50);
        }
        public virtual Rectangle ObjectBox(int scale)
        {
            return new Rectangle((int)pos.X, (int)pos.Y, animationFrames[currentFrame].Width * scale, animationFrames[currentFrame].Height * scale);
        }
        public virtual void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, animationFrames[currentFrame].Width * scale, animationFrames[currentFrame].Height * scale);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}
