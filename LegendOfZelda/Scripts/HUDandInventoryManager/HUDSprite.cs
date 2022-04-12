using System.Collections.Generic;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public class HUDSprite 
    {
        private readonly int xPos = 260, yPos = 12, width = 250, height = 55;

        Rectangle sourceRect;
        Rectangle compassMarkerSource = new Rectangle(519, 126, 3, 3);
        Texture2D HUDTexture, HUDText, level;
        public List<IHUDItem> HUDItems { get; private set; }

        public MapDisplaySprite mapDisplay = new MapDisplaySprite();
        public InventorySprite invSprite = new InventorySprite();
        public List<IHUDItem> Hearts { get; set; }
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

        List<IItem> invDisplayItems = new List<IItem>();

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
            // invSprite.shiftInventory(shiftDist, scale);
            invSprite.areVisible = true;
            foreach (IItem item in invDisplayItems) item.Position = new Vector2(item.Position.X, item.Position.Y + shiftDist.Y);
            foreach (IHUDItem heart in Hearts) heart.Position = new Vector2(heart.Position.X, heart.Position.Y + shiftDist.Y);
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
         
            //test for Inventory

        }
        public HUDSprite()
        {
            // SpriteSheet = HUDTexture;
            HUDItems = new List<IHUDItem>();
            Hearts = new List<IHUDItem>();
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
        public void AddHearts(string name, int xPos, int yPos)
        {
            Hearts.Add(HUDSpriteFactory.Instance.CreateHUDItemFromString(name));
            Hearts[^1].Position = new Vector2(xPos, yPos);
            Hearts[^1].name = name;
        }
        public void ChangeHeart(string name, int index) {
            Vector2 heartPos = Hearts[index].Position;
            if (name.Equals("EmptyHeart"))
            {
                Hearts.Insert(index, HUDSpriteFactory.Instance.CreateEmptyHeart());
                Hearts.RemoveAt(index + 1);
                Hearts[index].Position = heartPos;
                Hearts[index].name = name;
            } else if (name.Equals("HalfHeart"))
            {
                Hearts.Insert(index, HUDSpriteFactory.Instance.CreateHalfHeart());
                Hearts.RemoveAt(index + 1);
                Hearts[index].Position = heartPos;
                Hearts[index].name = name;
            } else
            {
                Hearts.Insert(index, HUDSpriteFactory.Instance.CreateFullHeart());
                Hearts.RemoveAt(index + 1);
                Hearts[index].Position = heartPos;
                Hearts[index].name = name;
            }

        }
        public void RemoveHeart()
        {
           if(Hearts.Count > 0) Hearts.RemoveAt(Hearts.Count-1);
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
            invSprite.getItemSprites(link);
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
        public void Update() 
        {
            foreach (IHUDItem HUDitem in HUDItems) HUDitem.Update();
            foreach (IHUDItem Heart in Hearts) Heart.Update();
            
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
                Rectangle compassMarkerDest = new Rectangle(153 * scale, 31 * scale, compassMarkerSource.Width * scale, compassMarkerSource.Height * scale);
                if (hasCompass)
                {
                    if (++compassTimer < 15) spriteBatch.Draw(HUDTexture, compassMarkerDest, compassMarkerSource, Color.White);
                    else if (compassTimer == 30) compassTimer = 0;
                }
            }

            if (invDisplayItems.Count >= 1)
            {
                invDisplayItems[0].Position = itemAPos;
                invDisplayItems[0].Draw(spriteBatch, scale);
            }

            if (invDisplayItems.Count >= 2)
            {
                invDisplayItems[1].Position = itemBPos;
                invDisplayItems[1].Draw(spriteBatch, scale);

            }

            
            
            foreach (IHUDItem Heart in Hearts)
            {
                Heart.Draw(spriteBatch, scale, offset);
            }

            //for testing purposes - leave till later
            mapDisplay.Draw(spriteBatch, scale, offset);
            invSprite.Draw(spriteBatch, scale, offset);
        }
    }
}
