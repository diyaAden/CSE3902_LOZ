using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class MapDisplaySprite 
    {

        private readonly int xPos = 0, yPos = 10, width = 256, height = 100;

        Rectangle sourceRect;
        Texture2D InventoryTexture;
        protected Vector2 pos = new Vector2(270, 200);
        
        public void LoadAllTextures(ContentManager content)
        {
            InventoryTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
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
            spriteBatch.Draw(InventoryTexture, pos, sourceRect, Color.White);
           
        }
    }
}
