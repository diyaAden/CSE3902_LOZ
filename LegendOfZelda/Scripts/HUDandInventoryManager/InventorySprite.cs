using LegendOfZelda.Scripts.Input.Controller;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class InventorySprite 
    {

        private readonly int xPos = 2, yPos = 20, width = 254, height = 78;

        Rectangle sourceRect;
        Texture2D InventoryTexture;
        public List<IItem> displayItems = new List<IItem>();
        Vector2 startPos = new Vector2(360,  80);

        Vector2 itemSelectBox = new Vector2(290, 75);
        IItem itemCursor;

        public bool areVisible = false;

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

        public void getItemPos() //add item sprites to list
        {
         
            int offs = 1;
          
            if (displayItems.Count < 4)
            {
                for (int i = 0; i < displayItems.Count; i++)
                {
                    displayItems[i].Position = new Vector2(startPos.X + (30 * offs), startPos.Y);
                    offs++;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                   // Debug.WriteLine("in display " + displayItems[i]);
                    displayItems[i].Position = new Vector2(startPos.X + (40 * offs), startPos.Y);
                    offs++;
                }
                offs = 1;
                for (int i = 4; i < displayItems.Count; i++)
                {
                   // Debug.WriteLine("in display " + displayItems[i]);
                    displayItems[i].Position = new Vector2(startPos.X + (40 * offs), startPos.Y + 40);
                    offs++;
                }
            }
        }

        public void shiftInventory(Vector2 shiftDist, int scale)
        {
            Position = new Vector2(Position.X, Position.Y + shiftDist.Y * scale);
        }

        public void checkCursorPos(KeyboardState k)
        {
            int pos = 0;
            //if user presses arrow key, depending on direction shift
            if (k.IsKeyDown(Keys.D) && pos < displayItems.Count )
            {
                pos++;
            }
            if (k.IsKeyDown(Keys.A) && pos > displayItems.Count)
            {
                pos--;
            }

            //if user clicks enter, update item cursor and B choice on HUD
            if (k.IsKeyDown(Keys.B))
            {
                itemCursor = displayItems[pos];
            }
        }
        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            spriteBatch.Draw(InventoryTexture, destRect, sourceRect, Color.White);

            if (displayItems.Count > 0)
            {
                itemCursor = displayItems[0];
                itemCursor.Position = itemSelectBox;
                itemCursor.Draw(spriteBatch, 2);
            }
            

          if (areVisible)
            {
                foreach (IItem i in displayItems)
                {
                    i.Draw(spriteBatch, 2);
                }
            } 
      
        }
    }
}
