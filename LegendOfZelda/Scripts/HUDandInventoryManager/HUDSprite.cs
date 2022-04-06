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
        protected Vector2 pos2 = new Vector2(190,10);
        Rectangle fullHeartSource;
        Rectangle halfHeartSource;
        Rectangle emptyHeartSource;
        Rectangle levelImageSource;
        Rectangle levelFrameSource;
        Rectangle tempRect;

        private GameScreenBorder border = new GameScreenBorder();

        public void LoadAllTextures(ContentManager content)
        {
            border.LoadTextures(content);

            HUDTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
            HUDText = content.Load<Texture2D>("SpriteSheets/General/HUDText");
            level = content.Load<Texture2D>("SpriteSheets/General/levelIcon");

            //test for Inventory

        }
        public HUDSprite()
        {
           // SpriteSheet = HUDTexture;
            sourceRect = new Rectangle(xPos, yPos, width, height);
            fullHeartSource = new Rectangle(20, 20, 20, 20);
            levelImageSource = new Rectangle(0, 0, 50, 26);
            levelFrameSource = new Rectangle(70, 1, 63, 8);
            tempRect = new Rectangle(80, 0, 152, 100);
        }
        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            Rectangle levelIconDestRect = new Rectangle(220, 55, levelImageSource.Width * scale, levelImageSource.Height * scale);
            Rectangle levelFrameDestRect = new Rectangle(200, 30, levelFrameSource.Width * scale, levelFrameSource.Height * scale);
            border.Draw(spriteBatch, scale, offset);
            spriteBatch.Draw(HUDTexture, destRect, sourceRect, Color.White);
            spriteBatch.Draw(HUDTexture, pos2, tempRect, Color.Black);
            spriteBatch.Draw(HUDText, levelFrameDestRect, levelFrameSource, Color.White);
            spriteBatch.Draw(level, levelIconDestRect, levelImageSource, Color.White);
        }
    }
}
