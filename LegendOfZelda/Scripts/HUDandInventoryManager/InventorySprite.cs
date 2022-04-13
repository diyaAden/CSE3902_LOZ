using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class InventorySprite 
    {

        private readonly int xPos = 2, yPos = 20, width = 254, height = 78;

        Rectangle sourceRect;
        Texture2D InventoryTexture;
        List<IItem> invDisplayItems = new List<IItem>();
        Vector2 startPos = new Vector2(320, -270);

        public bool areVisible = false;

        //List<Vector2> itemPos = { Vector2(500, 10) };
        public Vector2 Position { get; set; } = new Vector2(150, -350);
        
        public void LoadAllTextures(ContentManager content)
        {
            InventoryTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
        }
        public InventorySprite()
        {
           // SpriteSheet = HUDTexture;
            sourceRect = new Rectangle(xPos, yPos, width, height);
            
           
        }

        public void getItemSprites(ILink link) //add item sprites to list
        {
            invDisplayItems = link.getInventoryList();
            int offs = 1;
            for (int i = 0; i < invDisplayItems.Count; i++)
            {
                invDisplayItems[i].Position = new Vector2(startPos.X + (50 * offs), startPos.Y);
                offs++;
            }
            offs = 0;

        }

        public void shiftInventory(Vector2 shiftDist, int scale)
        {
            Position = new Vector2(Position.X, Position.Y + shiftDist.Y * scale);
            foreach (IItem item in invDisplayItems) item.Position = new Vector2(item.Position.X, item.Position.Y + shiftDist.Y);
        }

        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(InventoryTexture, destRect, sourceRect, Color.White);

            if (areVisible)
            {
                foreach (IItem i in invDisplayItems)
                {
                    i.Draw(spriteBatch, 2);
                }
            }
           


        }
    }
}
