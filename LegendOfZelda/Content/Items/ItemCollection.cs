using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items
{
    class ItemCollection
    {
        private List<IItem> items = new List<IItem>();
        private int currentItem = 0;

        public ItemCollection()
        {
            items.Add(ItemSpriteFactory.Instance.CreateCompassSprite());
            items.Add(ItemSpriteFactory.Instance.CreateMapSprite());
            items.Add(ItemSpriteFactory.Instance.CreateKeySprite());
            items.Add(ItemSpriteFactory.Instance.CreateHeartContainerSprite());
            items.Add(ItemSpriteFactory.Instance.CreateTriforcePieceSprite());
            items.Add(ItemSpriteFactory.Instance.CreateWoodBoomerangItemSprite());
            items.Add(ItemSpriteFactory.Instance.CreateMagicBoomerangItemSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBowSprite());
            items.Add(ItemSpriteFactory.Instance.CreateHeartSprite());
            items.Add(ItemSpriteFactory.Instance.CreateRupeeSprite());
            items.Add(ItemSpriteFactory.Instance.CreateArrowItemSprite());
            items.Add(ItemSpriteFactory.Instance.CreateMagicArrowItemSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBombItemSprite());
            items.Add(ItemSpriteFactory.Instance.CreateFireItemSprite()); //move fire to blocks
            items.Add(ItemSpriteFactory.Instance.CreateBlueRupeeSprite());
            items.Add(ItemSpriteFactory.Instance.CreateClockSprite());
            items.Add(ItemSpriteFactory.Instance.CreateFairySprite());
        }

        public void NextItem()
        {
            currentItem = ++currentItem % items.Count;
        }

        public void PreviousItem()
        {
            if (--currentItem < 0)
            {
                currentItem = items.Count - 1;
            }
        }

        public void Update()
        {
            items[currentItem].Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            items[currentItem].Draw(spriteBatch);
        }
    }
}
