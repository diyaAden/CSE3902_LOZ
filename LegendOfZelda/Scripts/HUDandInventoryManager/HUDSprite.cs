using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class HUDSprite 
    {
        private readonly int xPos = 250, yPos = 0, width = 256, height = 100;

        Rectangle sourceRect;
        Texture2D HUDTexture;
        protected Vector2 pos = new Vector2(270, 10);
        public void LoadAllTextures(ContentManager content)
        {
            HUDTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
        }
        public HUDSprite()
        {
           // SpriteSheet = HUDTexture;
            sourceRect = new Rectangle(xPos, yPos, width, height);
            //destRectangle = new Rectangle()
        }
        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(HUDTexture, pos, sourceRect, Color.White);
        }
    }
}
