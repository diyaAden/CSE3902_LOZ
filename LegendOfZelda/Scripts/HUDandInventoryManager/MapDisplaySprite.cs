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
        private IItem mapIcon;
        private bool hasMap = false;
        public Vector2 Position { get; set; } = new Vector2(190, -170);
        
        public void LoadAllTextures(ContentManager content)
        {
            MapTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
            mapIcon = ItemSpriteFactory.Instance.CreateMapSprite();
            mapIcon.Position = new Vector2(240, -130);
        }
        public MapDisplaySprite()
        {
            mapSource = new Rectangle(xPos1, yPos1, width1, height1);
            wordsSource = new Rectangle(xPos2, yPos2, width2, height2);
        }
        public void ShiftMapDisplay(Vector2 shiftDist, int scale)
        {
            Position = new Vector2(Position.X, Position.Y + shiftDist.Y * scale);
            mapIcon.Position = new Vector2(mapIcon.Position.X, mapIcon.Position.Y + shiftDist.Y * scale);
        }
        public void GetMap(bool hasMap) { this.hasMap = hasMap; }
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
            }
        }
    }
}
