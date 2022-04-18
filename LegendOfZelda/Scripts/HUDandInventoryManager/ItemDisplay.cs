using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class ItemDisplay 
    {

       // private readonly int xPos = 2, yPos = 20, width = 254, height = 78;

       // Rectangle sourceRect;
       // Texture2D InventoryTexture;
        public List<IItem> displayItems = new List<IItem>();
        Vector2 startPos = new Vector2(300, 10);

        public bool areVisible = false;

       // public Vector2 Position { get; set; } = new Vector2(150, -350);
        
        public void LoadAllTextures(ContentManager content)
        {
           // InventoryTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
        }
        public ItemDisplay()
        {
           // SpriteSheet = HUDTexture;
          //  sourceRect = new Rectangle(xPos, yPos, width, height);
            

            

        }

        public void getItemSprites() //add item sprites to list
        {
           // displayItems = link.getInventoryList();
            int offs = 1;

           // offs = 0;

            if (displayItems.Count < 3)
            {
                for (int i = 0; i < displayItems.Count; i++)
                {
                    displayItems[i].Position = new Vector2(startPos.X + (50 * offs), startPos.Y);
                    offs++;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                   // Debug.WriteLine("in display " + displayItems[i]);
                    displayItems[i].Position = new Vector2(startPos.X + (50 * offs), startPos.Y);
                    offs++;
                }
                offs = 1;
                for (int i = 3; i < displayItems.Count; i++)
                {
                   // Debug.WriteLine("in display " + displayItems[i]);
                    displayItems[i].Position = new Vector2(startPos.X + (50 * offs), startPos.Y + 30);
                    offs++;
                }
            }
        }

      

        public void Update() 
        { 

        }

        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {
           

           // if (areVisible)
           // {
                foreach (IItem i in displayItems)
                {
                    i.Draw(spriteBatch, 2);
                   // Debug.WriteLine("item displayed " + i);
                }
          //  }
           


        }
    }
}
