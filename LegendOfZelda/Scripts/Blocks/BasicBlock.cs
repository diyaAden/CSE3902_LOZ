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

        public abstract void Update();

        public Rectangle ObjectBox()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width, sourceRect.Height);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width, sourceRect.Height);
            spriteBatch.Draw(spriteSheet, destRect, sourceRect, Color.White * transparency);
        }
    }
}