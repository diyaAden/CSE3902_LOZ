using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class HUDInventoryManager
    {
        private readonly int xPos = 250, yPos = 10, width = 256, height = 60;

        Rectangle sourceRect;
        Texture2D HUDTexture;
        protected Vector2 pos = new Vector2(270, 10);
        public int rupees;
        public int keys;
        public bool hasMap; 
        public void LoadAllTextures(ContentManager content)
        {
            HUDTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
        }
        public HUDInventoryManager()
        {
           // SpriteSheet = HUDTexture;
            sourceRect = new Rectangle(xPos, yPos, width, height);
            //destRectangle = new Rectangle()
        }
        public void Update() 
        { 
            //update lives
            //check color for map
        }

        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(HUDTexture, pos, sourceRect, Color.White);
        }
    }
}
