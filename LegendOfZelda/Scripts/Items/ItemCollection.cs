using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Items
{
    class ItemCollection : ICollection
    {
        private List<IItem> itemCollection = new List<IItem>();
        private int currentObject = 0;

        public ItemCollection()
        {
            itemCollection.Add(ItemSpriteFactory.Instance.CreateCompassSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateMapSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateKeySprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateHeartContainerSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateTriforcePieceSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateWoodBoomerangItemSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateMagicBoomerangItemSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateBowSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateHeartSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateRupeeSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateArrowItemSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateMagicArrowItemSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateBombItemSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateBlueRupeeSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateClockSprite());
            itemCollection.Add(ItemSpriteFactory.Instance.CreateFairySprite());
        }
        public void Next()
        {
            currentObject = ++currentObject % itemCollection.Count;
        }

        public void Previous()
        {
            if (--currentObject < 0) { currentObject = itemCollection.Count - 1; }
        }

        public void Update()
        {
            itemCollection[currentObject].Update();
        }

        
        public IGameObject GameObject()
        {
            //return itemCollection[currentObject];
            return null;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            itemCollection[currentObject].Draw(spriteBatch);
        }
    }
}
