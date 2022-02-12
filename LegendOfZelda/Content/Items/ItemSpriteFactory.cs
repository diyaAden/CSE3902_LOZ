using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Content.Items;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LegendOfZelda.Content.Items.ItemSprites;

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
            return new CompassSprite(itemSpriteSheet, frames);
        }

        public IItem CreateMapSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(88, 0, 8, 16));
            return new MapSprite(itemSpriteSheet, frames);
        }

        public IItem CreateKeySprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(240, 0, 8, 16));
            return new KeySprite(itemSpriteSheet, frames);
        }

        public IItem CreateHeartContainerSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(25, 1, 13, 13));
            return new HeartContainerSprite(itemSpriteSheet, frames);
        }

        public IItem CreateTriforcePieceSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(275, 3, 10, 10));
            frames.Add(new Rectangle(275, 19, 10, 10));
            return new TriforcePieceSprite(itemSpriteSheet, frames);
        }

        public IItem CreateWoodBoomerangSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(129, 3, 5, 8));
            return new WoodBoomerangItemSprite(itemSpriteSheet, frames);
        }

        public IItem CreateBowSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(144, 0, 8, 16));
            return new BowSprite(itemSpriteSheet, frames);
        }

        public IItem CreateHeartSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(0, 0, 7, 8));
            frames.Add(new Rectangle(0, 8, 7, 8));
            return new HeartSprite(itemSpriteSheet, frames);
        }

        public IItem CreateRupeeSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(72, 0, 8, 16));
            frames.Add(new Rectangle(72, 16, 8, 16));
            return new RupeeSprite(itemSpriteSheet, frames);
        }

        public IItem CreateArrowItemSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(154, 0, 5, 16));
            return new ArrowItemSprite(itemSpriteSheet, frames);
        }

        public IItem CreateBombItemSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(136, 0, 8, 14));
            return new BombItemSprite(itemSpriteSheet, frames);
        }

        public IItem CreateFairySprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(40, 0, 8, 16));
            frames.Add(new Rectangle(48, 0, 8, 16));
            return new FairySprite(itemSpriteSheet, frames);
        }

        public IItem CreateBlueRupeeSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(72, 16, 8, 16));
            return new BlueRupeeSprite(itemSpriteSheet, frames);
        }

        public IItem CreateClockSprite()
        {
            frames = new List<Rectangle>();
            frames.Add(new Rectangle(58, 0, 11, 16));
            return new ClockSprite(itemSpriteSheet, frames);
        }
    }
}
