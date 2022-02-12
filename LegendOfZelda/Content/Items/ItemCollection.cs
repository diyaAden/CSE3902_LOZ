using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items
{
    class ItemCollection
    {
        private List<IItem> items;
        private int currentItem;

        public ItemCollection()
        {
            currentItem = 0;
            items = new List<IItem>();
            items.Add(ItemSpriteFactory.Instance.CreateCompassSprite());
            items.Add(ItemSpriteFactory.Instance.CreateMapSprite());
            items.Add(ItemSpriteFactory.Instance.CreateKeySprite());
            items.Add(ItemSpriteFactory.Instance.CreateHeartContainerSprite());
            items.Add(ItemSpriteFactory.Instance.CreateTriforcePieceSprite());
        }

        public void NextItem()
        {
            currentItem = ++currentItem % items.Count;
        }

        public void PreviousItem()
        {
            currentItem--;
            if (currentItem < 0)
            {
                currentItem = items.Count - 1;
            }
        }

        public IItem CurrentItem()
        {
            return items[currentItem];
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
