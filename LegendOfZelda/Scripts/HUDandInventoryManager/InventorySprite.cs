using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class InventorySprite 
    {

        private readonly int xPos = 2, yPos = 20, width = 254, height = 78;

        Rectangle sourceRect;
        Texture2D InventoryTexture;
        private IItem bow, bomb, boomerang;
        private bool hasBow = true, hasBomb = true, hasBoomerang = true;
        public Vector2 Position { get; set; } = new Vector2(150, -350);
        
        public void LoadAllTextures(ContentManager content)
        {
            InventoryTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
            bow = ItemSpriteFactory.Instance.CreateBowSprite();
            bow.Position = new Vector2(506, -270);
            bomb = ItemSpriteFactory.Instance.CreateBombItemSprite();
            bomb.Position = new Vector2(410, -270);
            boomerang = ItemSpriteFactory.Instance.CreateWoodBoomerangItemSprite();
            boomerang.Position = new Vector2(458, -265);
        }
        public void ShiftHUD(Vector2 shiftDist, int scale)
        {
            Position = new Vector2(Position.X, Position.Y + shiftDist.Y * scale);
            bomb.Position = new Vector2(bomb.Position.X, bomb.Position.Y + shiftDist.Y * scale);
            boomerang.Position = new Vector2(boomerang.Position.X, boomerang.Position.Y + shiftDist.Y * scale);
            bow.Position = new Vector2(bow.Position.X, bow.Position.Y + shiftDist.Y * scale);
        }
        public InventorySprite()
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
            spriteBatch.Draw(InventoryTexture, destRect, sourceRect, Color.White);
            if (hasBomb) bomb.Draw(spriteBatch, scale);
            if (hasBoomerang) boomerang.Draw(spriteBatch, scale);
            if (hasBow) bow.Draw(spriteBatch, scale);
        }
    }
}
