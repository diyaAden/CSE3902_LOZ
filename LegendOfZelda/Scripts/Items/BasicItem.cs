using Microsoft.Xna.Framework;
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

        public virtual void Update() { }

        public virtual void Update(Vector2 linkPosition) { }

        public virtual Rectangle ObjectBox()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, animationFrames[currentFrame].Width, animationFrames[currentFrame].Height);
            spriteBatch.Draw(spriteSheet, destRect, animationFrames[currentFrame], Color.White);
        }
    }
}
