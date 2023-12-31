﻿using System.Collections.Generic;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class HUDSprite 
    {
        private readonly int xPos = 260, yPos = 12, width = 250, height = 55;

        Rectangle sourceRect;
        Rectangle compassMarkerSource = new Rectangle(519, 126, 3, 3);
        Rectangle triforceMarkerSource = new Rectangle(528, 126, 3, 3);
        Texture2D HUDTexture, HUDText, level;
        public List<IHUDItem> HUDItems { get; private set; }

        public MapDisplaySprite mapDisplay;
        public InventorySprite invSprite = new InventorySprite();
        
        public bool hasMap = false, hasCompass = false;
        private int compassTimer = 0;
        protected Vector2 pos = new Vector2(170, 10), pos2 = new Vector2(190,10), mapPos = new Vector2(220, 55);
        protected Vector2 levelFramePos = new Vector2(200, 30), levelNumPos = new Vector2(295, 24);
        protected Vector2 rupeeCountPos = new Vector2(360, 36), keyCountPos = new Vector2(360, 65), bombCountPos = new Vector2(360, 85);
        protected Vector2 itemAPos = new Vector2(470, 60), itemBPos = new Vector2(420, 60);
        Rectangle levelImageSource, levelFrameSource, tempRect;
        Rectangle destRectSlotA, destRectSlotB;
        public SpriteFont font;
        public string rupeesText, keysText, bombsText;
        IItem slotA, slotB;
        public int nRupees { get; set; }
        public int nKeys { get; set; }
        public int nBombs { get; set; }
        private Rectangle compassMarkerDest, triforceMarkerDest;
        private MapRoomLocations roomLocations = new MapRoomLocations();
        public bool isVisible = false;
        public bool isUsable = false;
        public int currentItem = 1;
        public List<IItem> invDisplayItems = new List<IItem>();

        public Texture2D itemSheet;
        private GameScreenBorder border = new GameScreenBorder();
        private Vector2 position = new Vector2(0, 0);
        public void ShiftHUD(Vector2 shiftDist, int scale)
        {
            position = new Vector2(position.X, position.Y + shiftDist.Y * scale);
            pos = new Vector2(pos.X, pos.Y + shiftDist.Y * scale);
            pos2 = new Vector2(pos.X, pos2.Y + shiftDist.Y * scale);
            mapPos = new Vector2(mapPos.X, mapPos.Y + shiftDist.Y * scale);
            border.Position = new Vector2(border.Position.X, border.Position.Y + shiftDist.Y * scale);
            levelFramePos = new Vector2(levelFramePos.X, levelFramePos.Y + shiftDist.Y * scale);
            levelNumPos = new Vector2(levelNumPos.X, levelNumPos.Y + shiftDist.Y * scale);
            rupeeCountPos = new Vector2(rupeeCountPos.X, rupeeCountPos.Y + shiftDist.Y * scale);
            keyCountPos = new Vector2(keyCountPos.X, keyCountPos.Y + shiftDist.Y * scale);
            bombCountPos = new Vector2(bombCountPos.X, bombCountPos.Y + shiftDist.Y * scale);
            itemAPos = new Vector2(itemAPos.X, itemAPos.Y + shiftDist.Y * scale);
            itemBPos = new Vector2(itemBPos.X, itemBPos.Y + shiftDist.Y * scale);
            invSprite.Position = new Vector2(invSprite.Position.X, invSprite.Position.Y + shiftDist.Y * scale);
            mapDisplay.ShiftMapDisplay(shiftDist, scale);
            foreach (IItem item in invDisplayItems) item.Position = new Vector2(item.Position.X, item.Position.Y + shiftDist.Y);
            foreach (IHUDItem item in HUDItems) item.Position = new Vector2(item.Position.X, item.Position.Y + shiftDist.Y);
            
        }
        public void LoadAllTextures(ContentManager content)
        {
            border.LoadTextures(content);
            mapDisplay.LoadAllTextures(content);
            invSprite.LoadAllTextures(content);
            HUDTexture = content.Load<Texture2D>("SpriteSheets/General/HUDPauseScreen");
            HUDText = content.Load<Texture2D>("SpriteSheets/General/HUDText");
            level = content.Load<Texture2D>("SpriteSheets/General/levelIcon");
            font = content.Load<SpriteFont>("SpriteSheets/General/textFont");
         

        }
        public HUDSprite(int currentRoom)
        {
            mapDisplay = new MapDisplaySprite();
            HUDItems = new List<IHUDItem>();
            
            sourceRect = new Rectangle(xPos, yPos, width, height);
            levelImageSource = new Rectangle(0, 0, 50, 26);
            levelFrameSource = new Rectangle(70, 1, 63, 8);
            tempRect = new Rectangle(80, 0, 152, 100);
            destRectSlotA = new Rectangle(120, 20, 100, 100);
            
        }
        public void AddObject(string name, int xPos, int yPos)
        {
            HUDItems.Add(HUDSpriteFactory.Instance.CreateHUDItemFromString(name));
            HUDItems[^1].Position = new Vector2(xPos, yPos);
            HUDItems[^1].name = name;
        }

        public int findObject(string name) {
            for ( int i = HUDItems.Count-1; i > 0; i--) {
                    if( HUDItems[i].name.Equals(name)) {
                        return i;
                    } 
             }
            return 0;

        }

        public void getItemSprites(ILink link) //add item sprites to list
        {
            invDisplayItems = link.getInventoryList();
            invSprite.SetInventory(link.getInventoryList());
           
            hasMap = link.HasMap;
            hasCompass = link.HasCompass;
            mapDisplay.GetMapAndCompass(hasMap, hasCompass);
        }

        public void updateItemCounts(ILink link)
        {
            nRupees = link.numRupees;
            nKeys = link.numKeys;
            nBombs = link.numBombs;
        }
        public void Update(int currentRoom, KeyboardState k) 
        {
            invSprite.checkCursorPos(k);
            mapDisplay.addToRoomList(currentRoom);
            foreach (IHUDItem HUDitem in HUDItems) HUDitem.Update();
            
            Vector2 roomDestination = roomLocations.RoomLocation(currentRoom);
            Vector2 triforceRoom = roomLocations.RoomLocation(15);
            compassMarkerDest = new Rectangle((int)roomDestination.X *2, (int)roomDestination.Y*2, compassMarkerSource.Width * 2, compassMarkerSource.Height * 2);
            triforceMarkerDest = new Rectangle((int)triforceRoom.X * 2, (int)triforceRoom.Y * 2, compassMarkerSource.Width * 2, compassMarkerSource.Height * 2);
        }
        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset)
        {

            
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, sourceRect.Width * scale, sourceRect.Height * scale);
            Rectangle levelIconDestRect = new Rectangle((int)mapPos.X, (int)mapPos.Y, levelImageSource.Width * scale, levelImageSource.Height * scale);
            Rectangle levelFrameDestRect = new Rectangle((int)levelFramePos.X, (int)levelFramePos.Y, levelFrameSource.Width * scale, levelFrameSource.Height * scale);
            
            border.Draw(spriteBatch, scale, offset);
            spriteBatch.Draw(HUDTexture, destRect, sourceRect, Color.White);
            spriteBatch.Draw(HUDTexture, pos2, tempRect, Color.Black);

            spriteBatch.Draw(HUDText, levelFrameDestRect, levelFrameSource, Color.White);
            foreach (IHUDItem HUDitem in HUDItems)
            {
                HUDitem.Draw(spriteBatch, scale, offset);
            }

            spriteBatch.DrawString(font, "1", levelNumPos, Color.White);
            spriteBatch.DrawString(font, "x" + nRupees, rupeeCountPos, Color.White);
            spriteBatch.DrawString(font, "x" + nKeys, keyCountPos, Color.White);
            spriteBatch.DrawString(font, "x" + nBombs, bombCountPos, Color.White);
            if (hasMap)
            {
                spriteBatch.Draw(level, levelIconDestRect, levelImageSource, Color.White);
                if (hasCompass)
                {
                    if (++compassTimer < 15)
                    {
                        spriteBatch.Draw(HUDTexture, compassMarkerDest, compassMarkerSource, Color.White);
                        spriteBatch.Draw(HUDTexture, triforceMarkerDest, triforceMarkerSource, Color.White);
                    }
                    else if (compassTimer == 30) compassTimer = 0;
                }
            }

            if (invDisplayItems.Count >= 1)
            {
                invDisplayItems[0].Position = itemAPos;
                invDisplayItems[0].Draw(spriteBatch, scale);
            }

             if (invDisplayItems.Count >= currentItem + 1 && invSprite.itemCursor != null)
              {
                currentItem = invSprite.itemIndex;
                slotB = invSprite.itemCursor;
                slotB.Position = new Vector2(itemBPos.X, itemBPos.Y);
                slotB.Draw(spriteBatch, scale);

            }



            if (isVisible)
            {
                invSprite.areVisible = true;
                mapDisplay.areVisible = true;
            }
            else
            {
                invSprite.areVisible = false;
                mapDisplay.areVisible = false;
            }


            if (isUsable) invSprite.areUsable = true;
            else invSprite.areUsable = false;

            mapDisplay.Draw(spriteBatch, scale, offset);
            invSprite.getItemPos();
            invSprite.Draw(spriteBatch, scale, offset);
         
        }
    }
}
