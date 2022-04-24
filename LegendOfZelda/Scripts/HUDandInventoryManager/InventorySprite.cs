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
        List<IItem> displayItems = new List<IItem>();
        Vector2 startPos = new Vector2(360,  80);

        public Vector2 itemSelectBox = new Vector2(290, 75);
        public IItem itemCursor;
        public int itemIndex = 1;
        public bool areVisible = false;
        public int cursorCoolDown = 0;
        public int cursorCoolDownLimit = 10;
        Texture2D indicatorSprTexture;
        public Vector2 Position { get; set; } = new Vector2(150, -350);

        Vector2 indicatorPos = new Vector2(400, 80);

        public void SetInventory(List<IItem> linkInv)
        {
            displayItems = linkInv;
        }
        public void LoadAllTextures(ContentManager content)
        {
            InventoryTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
            indicatorSprTexture = content.Load<Texture2D>("SpriteSheets/General/indicatorSprite");
        }
        public InventorySprite()
        {
           // SpriteSheet = HUDTexture;
            sourceRect = new Rectangle(xPos, yPos, width, height);

            if (displayItems.Count > 0)
            {
                itemCursor = displayItems[0];
                itemCursor.Position = itemSelectBox;
              //  itemCursor.Draw(spriteBatch, 2);
            }


        }

        public void getItemPos() //add item sprites to list
        {
         
            int offs = 1;
          
            if (displayItems.Count < 4)
            {
                for (int i = 0; i < displayItems.Count; i++)
                {
                    displayItems[i].Position = new Vector2(startPos.X + (50 * offs), startPos.Y);
                    offs++;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                   // Debug.WriteLine("in display " + displayItems[i]);
                    displayItems[i].Position = new Vector2(startPos.X + (50 * offs), startPos.Y);
                    offs++;
                }
                offs = 1;
                for (int i = 4; i < displayItems.Count; i++)
                {
                   // Debug.WriteLine("in display " + displayItems[i]);
                    displayItems[i].Position = new Vector2(startPos.X + (50 * offs), startPos.Y + 50);
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
            
            //if user presses arrow key, depending on direction shift
            if (k.IsKeyDown(Keys.J) && itemIndex < displayItems.Count - 1 && cursorCoolDown == 0 )
            {
                itemIndex++;
                cursorCoolDown = cursorCoolDownLimit;
            }
            if (k.IsKeyDown(Keys.G) && itemIndex > 0 && cursorCoolDown == 0)
            {
                itemIndex--;
                cursorCoolDown = cursorCoolDownLimit;
            }

            if (cursorCoolDown > 0)
            {
                cursorCoolDown--;
                indicatorPos = new Vector2(displayItems[itemIndex].Position.X - 10, displayItems[itemIndex].Position.Y);
            }
            //if user clicks enter, update item cursor and B choice on HUD
            if (k.IsKeyDown(Keys.B) && displayItems.Count > 0 )
            {
                Debug.WriteLine("change registered" + itemIndex);
                itemCursor = displayItems[itemIndex];
                //set indicator box to same pos as item
               // indicatorPos = new Vector2(displayItems[pos].Position.X, displayItems[pos].Position.Y);
            }
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
                if (displayItems.Count > 0 && itemCursor != null)
                {
                    itemCursor.Position = itemSelectBox;
                    itemCursor.Draw(spriteBatch, 2);
                }

                spriteBatch.Draw(indicatorSprTexture, indicatorPos, Color.White);
                foreach (IItem i in displayItems)
                {
                    i.Draw(spriteBatch, 2);
                }
            } 
      
        }
    }
}
