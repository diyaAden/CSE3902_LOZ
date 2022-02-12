using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Content.Items;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LegendOfZelda.Content.Items.ItemClasses;

namespace LegendOfZelda.Content.Items
{
    public class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;
        private List<Rectangle> frames;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("SpriteSheets/itemSpriteSheet");
        }

        public IItem CreateCompassSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(258, 1, 11, 12));
            return new AbstractItem(itemSpriteSheet, frames);
        }

        public IItem CreateMapSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(88, 0, 8, 16));
            frames.Add(new Rectangle(88, 16, 8, 16));
            return new AbstractItem(itemSpriteSheet, frames);
        }

        public IItem CreateKeySprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(240, 0, 8, 16));
            return new AbstractItem(itemSpriteSheet, frames);
        }

        public IItem CreateHeartContainerSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(25, 1, 13, 13));
            return new AbstractItem(itemSpriteSheet, frames);
        }

        public IItem CreateTriforcePieceSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(275, 3, 10, 10));
            frames.Add(new Rectangle(275, 19, 10, 10));
            return new AbstractItem(itemSpriteSheet, frames);
        }

        public IItem CreateWoodBoomerangSprite()
        {
            return null;
        }

        public IItem CreateBowSprite()
        {
            return null;
        }

        public IItem CreateHeartSprite()
        {
            return null;
        }

        public IItem CreateRupeeSprite()
        {
            return null;
        }

        public IItem CreateArrowSprite()
        {
            return null;
        }

        public IItem CreateBombSprite()
        {
            return null;
        }

        public IItem CreateFairySprite()
        {
            return null;
        }

        public IItem CreateClockSprite()
        {
            return null;
        }

        //Other sprites may be necessary
    }
}
