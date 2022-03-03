using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public abstract class BasicRoomBackground : IRoomBackground
    {
        public virtual Texture2D spriteSheet { get; set; }
        protected Rectangle sourceRect;
        protected Vector2 pos = new Vector2(0, 0);
        public Vector2 position { get { return pos; } set { pos = value; } }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width, sourceRect.Height);
            spriteBatch.Draw(spriteSheet, destRect, sourceRect, Color.White);
        }
    }
}


