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
        private Texture2D itemSpriteSheet, fairySpriteSheet, heartSpriteSheet, rupeeSpriteSheet, triforcePieceSpriteSheet, arrowSwordSpriteSheet;
        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance => instance;
        private ItemSpriteFactory()
        {
        }
        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/ItemSpriteSheet");
            fairySpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/FairySpriteSheet");
            heartSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/HeartSpriteSheet");
            rupeeSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/RupeeSpriteSheet");
            triforcePieceSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/TriforcePieceSpriteSheet");
            arrowSwordSpriteSheet = content.Load<Texture2D>("SpriteSheets/Items/ArrowSwordSpriteSheet");
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
            return new TriforcePieceSprite(triforcePieceSpriteSheet);
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
            return new HeartSprite(heartSpriteSheet);
        }
        public IItem CreateRupeeSprite()
        {
            return new RupeeSprite(rupeeSpriteSheet);
        }
        public IItem CreateArrowItemSprite()
        {
            return new ArrowItemSprite(arrowSwordSpriteSheet);
        }
        public IItem CreateMagicArrowItemSprite()
        {
            return new MagicArrowItemSprite(arrowSwordSpriteSheet);
        }
        public IItem CreateBombItemSprite()
        {
            return new BombItemSprite(itemSpriteSheet);
        }
        public IItem CreateFairySprite()
        {
            return new FairySprite(fairySpriteSheet);
        }
        public IItem CreateBlueRupeeSprite()
        {
            return new BlueRupeeSprite(rupeeSpriteSheet);
        }
        public IItem CreateClockSprite()
        {
            return new ClockSprite(itemSpriteSheet);
        }
    }
}
