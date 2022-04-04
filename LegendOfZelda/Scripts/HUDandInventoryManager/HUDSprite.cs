using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class HUDSprite
    {
        private readonly int xPos = 260, yPos = 12, width = 250, height = 55;

        Rectangle sourceRect;
        Texture2D HUDTexture;
        Texture2D HUDText;
        Texture2D level;

        protected Vector2 pos = new Vector2(170, 10);
        Rectangle fullHeartSource;
        Rectangle halfHeartSource;
        Rectangle emptyHeartSource;
        Rectangle levelImageSource;

        public void LoadAllTextures(ContentManager content)
        {
            HUDTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
            HUDText = content.Load<Texture2D>("SpriteSheets/General/HUDText");
            level = content.Load<Texture2D>("SpriteSheets/General/levelIcon");
        }
        public HUDSprite()
        {
           // SpriteSheet = HUDTexture;
            sourceRect = new Rectangle(xPos, yPos, width, height);
            fullHeartSource = new Rectangle(20, 20, 20, 20);
            levelImageSource = new Rectangle(0, 0, 50, 25);
        }
        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * 2, sourceRect.Height * 2);
            Rectangle levelIconDestRect = new Rectangle(220, 50, levelImageSource.Width * 2, levelImageSource.Height * 2);
            spriteBatch.Draw(HUDTexture, destRect, sourceRect, Color.White);
            spriteBatch.Draw(level, levelIconDestRect, levelImageSource, Color.White);
        }
    }
}
