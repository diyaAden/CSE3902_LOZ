using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks
{
    public abstract class BasicBlock : IBlock
    {
        protected Texture2D spriteSheet;
        protected Rectangle sourceRect;
        protected Vector2 pos = new Vector2(400, 100);
        protected bool enabled = true;
        protected float transparency = 1f;
        public virtual Vector2 Position { get { return pos; } set { pos = value; } }
        public int AdjacentRoom { get; set; }
        public virtual void Disable() { }
        public abstract void Update();
        public virtual void HandleCollision(ICollision side, int scale) { }

        public virtual Rectangle ObjectBox(int scale)
        {
            if (enabled)
                return new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            else
                return new Rectangle();
        }
        public virtual void Draw(SpriteBatch spriteBatch, int scale)
        {
            if (enabled)
            {
                Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
                spriteBatch.Draw(spriteSheet, destRect, sourceRect, Color.White * transparency);
            }
        }
    }
}