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
        private Texture2D NPCSpriteSheet;
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
            NPCSpriteSheet = content.Load<Texture2D>("SpriteSheets/NPCSpriteSheet");
        }
        public IItem CreateCompassSprite()
        {
            return new CompassSprite(itemSpriteSheet);
        }
        public IItem CreateMapSprite()
        {
            return new MapSprite(itemSpriteSheet);
        }
        public IItem CreateKeySprite()
        {
            return new KeySprite(itemSpriteSheet);
        }
        public IItem CreateHeartContainerSprite()
        {
            return new HeartContainerSprite(itemSpriteSheet);
        }
        public IItem CreateTriforcePieceSprite()
        {
            return new TriforcePieceSprite(itemSpriteSheet);
        }
        public IItem CreateWoodBoomerangItemSprite()
        {
            return new WoodBoomerangItemSprite(itemSpriteSheet);
        }
        public IItem CreateMagicBoomerangItemSprite()
        {
            return new MagicBoomerangItemSprite(itemSpriteSheet);
        }
        public IItem CreateBowSprite()
        {
            return new BowSprite(itemSpriteSheet);
        }
        public IItem CreateHeartSprite()
        {
            return new HeartSprite(itemSpriteSheet);
        }
        public IItem CreateRupeeSprite()
        {
            return new RupeeSprite(itemSpriteSheet);
        }
        public IItem CreateArrowItemSprite()
        {
            return new ArrowItemSprite(itemSpriteSheet);
        }
        public IItem CreateMagicArrowItemSprite()
        {
            return new MagicArrowItemSprite(itemSpriteSheet);
        }
        public IItem CreateBombItemSprite()
        {
            return new BombItemSprite(itemSpriteSheet);
        }
        public IItem CreateFairySprite()
        {
            return new FairySprite(itemSpriteSheet);
        }
        public IItem CreateFireItemSprite()
        {
            return new FireItemSprite(NPCSpriteSheet);
        }
        public IItem CreateBlueRupeeSprite()
        {
            return new BlueRupeeSprite(itemSpriteSheet);
        }
        public IItem CreateClockSprite()
        {
            return new ClockSprite(itemSpriteSheet);
        }
    }
}
