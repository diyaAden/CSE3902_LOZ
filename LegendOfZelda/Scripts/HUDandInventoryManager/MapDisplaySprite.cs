using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class MapDisplaySprite 
    {

        private readonly int xPos = 280, yPos = 115, width = 230, height = 80;

        public Rectangle sourceRect;
        Texture2D MapTexture;
        protected Vector2 pos = new Vector2(270, 200);
        
        public void LoadAllTextures(ContentManager content)
        {
            MapTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
        }
        public MapDisplaySprite()
        {
           // SpriteSheet = HUDTexture;
            sourceRect = new Rectangle(xPos, yPos, width, height);
           
           
        }
        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(MapTexture, pos, sourceRect, Color.White);
           
        }
    }
}
