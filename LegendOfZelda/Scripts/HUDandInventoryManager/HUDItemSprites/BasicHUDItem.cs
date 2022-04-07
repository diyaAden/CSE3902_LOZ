using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public abstract class BasicHUDItem : IHUDItem
    {
        public string name { get; set; }
        public virtual Texture2D SpriteSheet { get; set; }
        protected Rectangle sourceRect;
        //protected Vector2 pos = new Vector2(0, 0);
        protected float transparency = 1f;
        public Vector2 Position { get; set; }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
            Rectangle destRect = new Rectangle((int) Position.X*scale + (int)offset.X *scale, (int) Position.Y*scale, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(SpriteSheet, destRect, sourceRect, Color.White * transparency);
        }
    }
}


