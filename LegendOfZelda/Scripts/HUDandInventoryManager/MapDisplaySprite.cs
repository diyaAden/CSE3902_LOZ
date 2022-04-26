using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class MapDisplaySprite 
    {

        private readonly int xPos1 = 340, yPos1 = 115, width1 = 170, height1 = 80;
        private readonly int xPos2 = 280, yPos2 = 115, width2 = 60, height2 = 80;

        public Rectangle mapSource, wordsSource;
        Texture2D MapTexture;
        Texture2D compassMap;
        private IItem mapIcon, compassIcon;
        private bool hasMap = false, hasCompass = false;
        public Vector2 Position { get; set; } = new Vector2(190, -170);
        public Vector2 compassMapPos = new Vector2(400, -160);
        CompassMapDisplay c = new CompassMapDisplay();
        
        public void LoadAllTextures(ContentManager content)
        {
            c.LoadAllTextures(content);
            MapTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
            compassMap = content.Load<Texture2D>("SpriteSheets/General/FullMap");
            mapIcon = ItemSpriteFactory.Instance.CreateMapSprite();
            mapIcon.Position = new Vector2(240, -130);
            compassIcon = ItemSpriteFactory.Instance.CreateCompassSprite();
            compassIcon.Position = new Vector2(235, -50);
        }
        public MapDisplaySprite()
        {
            mapSource = new Rectangle(xPos1, yPos1, width1, height1);
            wordsSource = new Rectangle(xPos2, yPos2, width2, height2);
        }
        public void ShiftMapDisplay(Vector2 shiftDist, int scale)
        {
            Position = new Vector2(Position.X, Position.Y + shiftDist.Y * scale);
            compassMapPos = new Vector2(compassMapPos.X, compassMapPos.Y + shiftDist.Y * scale);
            mapIcon.Position = new Vector2(mapIcon.Position.X, mapIcon.Position.Y + shiftDist.Y * scale); compassIcon.Position = new Vector2(compassIcon.Position.X, compassIcon.Position.Y + shiftDist.Y * scale);
        }
        public void GetMapAndCompass(bool hasMap, bool hasCompass)
        {
            this.hasMap = hasMap;
            this.hasCompass = hasCompass;
        }

        public void addToRoomList(int i)
        {
            if (!c.roomsToDraw.Contains(i)) c.roomsToDraw.Add(i);
        }
        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
            Rectangle wordsDest = new Rectangle((int)Position.X, (int)Position.Y, wordsSource.Width * scale, wordsSource.Height * scale);
            Rectangle mapDest = new Rectangle((int)Position.X + 60 * scale, (int)Position.Y, mapSource.Width * scale, mapSource.Height * scale);
            spriteBatch.Draw(MapTexture, wordsDest, wordsSource, Color.White);
           
            if (hasMap) 
            {
                mapIcon.Draw(spriteBatch, scale);
                spriteBatch.Draw(MapTexture, mapDest, mapSource, Color.White);
                // spriteBatch.Draw(compassMap, compassMapPos, Color.White);
                c.Draw(spriteBatch, scale);
            }
            
            if (hasCompass) compassIcon.Draw(spriteBatch, scale);
        }
    }
}
