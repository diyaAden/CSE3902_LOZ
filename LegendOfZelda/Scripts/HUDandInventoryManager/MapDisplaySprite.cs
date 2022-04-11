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
        public Vector2 Position { get; set; } = new Vector2(190, -170);
        
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
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(MapTexture, destRect, sourceRect, Color.White);
           
        }
    }
}
