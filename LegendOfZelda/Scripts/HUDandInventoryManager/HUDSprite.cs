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
        Texture2D HUDTexture;
        Texture2D HUDText;
        Texture2D level;
        public List<IHUDItem> HUDItems { get; private set; }

        public MapDisplaySprite mapDisplay = new MapDisplaySprite();
        public InventorySprite invSprite = new InventorySprite();
        public List<IHUDItem> Hearts { get; set; }
        public bool hasMap = false;

        protected Vector2 pos = new Vector2(170, 10);
        protected Vector2 pos2 = new Vector2(190,10);
        Rectangle levelImageSource;
        Rectangle levelFrameSource;
        Rectangle tempRect;
        Rectangle destRectSlotA;
        Rectangle destRectSlotB;
        public SpriteFont font;
        public string rupeesText;
        public string keysText;
        public string bombsText;
        IItem slotA;
        IItem slotB;
        public int nRupees { get; set; }
        public int nKeys { get; set; }
        public int nBombs { get; set; }

        List<IItem> invDisplayItems = new List<IItem>();

        public Texture2D itemSheet;

        private GameScreenBorder border = new GameScreenBorder();

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
                Hearts.Add(HUDSpriteFactory.Instance.CreateEmptyHeart());
                Hearts[^1].Position = heartPos;
                Hearts[^1].name = name;
            } else if (name.Equals("HalfHeart"))
            {
                Hearts.Add(HUDSpriteFactory.Instance.CreateHalfHeart());
                Hearts[^1].Position = heartPos;
                Hearts[^1].name = name;
            } else
            {
                Hearts.Add(HUDSpriteFactory.Instance.CreateFullHeart());
                Hearts[^1].Position = heartPos;
                Hearts[^1].name = name;
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
            hasMap = link.HasMap;
           
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
            Rectangle levelIconDestRect = new Rectangle(220, 55, levelImageSource.Width * scale, levelImageSource.Height * scale);
            Rectangle levelFrameDestRect = new Rectangle(200, 30, levelFrameSource.Width * scale, levelFrameSource.Height * scale);
            
            border.Draw(spriteBatch, scale, offset);
            spriteBatch.Draw(HUDTexture, destRect, sourceRect, Color.White);
            spriteBatch.Draw(HUDTexture, pos2, tempRect, Color.Black);

            spriteBatch.Draw(HUDText, levelFrameDestRect, levelFrameSource, Color.White);

            spriteBatch.DrawString(font, "1", new Vector2(295, 24), Color.White);
            spriteBatch.DrawString(font, "x" + nRupees, new Vector2(360, 36), Color.White);
            spriteBatch.DrawString(font, "x" + nKeys, new Vector2(360, 65), Color.White);
            spriteBatch.DrawString(font, "x" + nBombs, new Vector2(360, 85), Color.White);
            if (hasMap)
            {
                spriteBatch.Draw(level, levelIconDestRect, levelImageSource, Color.White);
            }

            if (invDisplayItems.Count >= 1)
            {
                invDisplayItems[0].Position = new Vector2(470,60);
                invDisplayItems[0].Draw(spriteBatch, 2);
            }

            if (invDisplayItems.Count >= 2)
            {
                invDisplayItems[1].Position = new Vector2(420, 60);
                invDisplayItems[1].Draw(spriteBatch, 2);

            }

            
            foreach (IHUDItem HUDitem in HUDItems)
            {
                HUDitem.Draw(spriteBatch, scale, offset);
            }
            foreach (IHUDItem Heart in Hearts)
            {
                Heart.Draw(spriteBatch, scale, offset);
            }

            //for testing purposes - leave till later
            // mapDisplay.Draw(spriteBatch, 2, offset);
           // invSprite.Draw(spriteBatch, 2, offset);
        }
    }
}
