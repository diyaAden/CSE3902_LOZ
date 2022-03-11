using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks
{
    public abstract class BasicBlock : IBlock
    {
        protected Texture2D spriteSheet;
        protected Rectangle sourceRect;
        protected Vector2 pos = new Vector2(400, 100);

        protected float transparency;
        public Vector2 position { get { return pos; } set { pos = value; } }
        public int adjacentRoom { get; set; }

        public abstract void Update();

        public virtual Rectangle ObjectBox(int scale)
        {
            return new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
        }
        public virtual void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(spriteSheet, destRect, sourceRect, Color.White * transparency);
        }
    }
}