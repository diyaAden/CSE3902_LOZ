using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class InventorySprite 
    {

        private readonly int xPos = 250, yPos = 0, width = 256, height = 100;

        HUDSprite HUDSpr = new HUDSprite();
        Rectangle sourceRect;
        Texture2D InventoryTexture;
        protected Vector2 pos = new Vector2(270, 10);
        
        public void LoadAllTextures(ContentManager content)
        {
            InventoryTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
        }
        public InventorySprite()
        {
           // SpriteSheet = HUDTexture;
            sourceRect = new Rectangle(xPos, yPos, width, height);
            //destRectangle = new Rectangle()
        }
        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(InventoryTexture, pos, sourceRect, Color.White);
            HUDSpr.Draw(spriteBatch, scale, offset); //draw HUD Sprite (needs to be bottom of screen)
        }
    }
}
