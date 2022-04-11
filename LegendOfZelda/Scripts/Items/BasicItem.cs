using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Items
{
    public abstract class BasicItem : IItem
    {
        private Vector2 itemOffset = new Vector2(5, 2);
        protected Texture2D spriteSheet;
        protected List<Rectangle> animationFrames = new List<Rectangle>();
        protected int currentFrame = 0, timerLimit = -1, animationTimer = 1;
        protected Vector2 pos = new Vector2(400, 200);
        protected string name;

        public int TimeLimit => timerLimit;
        public virtual Vector2 Position { get { return pos; } set { pos = value; } }
        public int AnimationTimer { get { return animationTimer; } set { animationTimer = value; } }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public virtual void Update() { }

        public virtual void Update(Vector2 linkPosition) { }
        public virtual void HandleCollision(ICollision side, int scale) { }
        public void HandleCollision(ICollision side, int scale, Vector2 screenOffset) { }
        public virtual void PickItem(Vector2 linkPosition, int scale)
        {
            SoundController.Instance.PlayGetItemSound();
            pos = new Vector2(linkPosition.X + itemOffset.X * scale, linkPosition.Y - (itemOffset.Y + animationFrames[currentFrame].Height) * scale);
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
