using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public abstract class BasicRoomBackground : IRoomBackground
    {
        public virtual Texture2D SpriteSheet { get; set; }
        protected Rectangle sourceRect;
        protected Vector2 pos = new Vector2(0, 0);
        protected float transparency = 1f;
        public Vector2 Position { get { return pos; } set { pos = value; } }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(SpriteSheet, destRect, sourceRect, Color.White * transparency);
        }
    }
}


