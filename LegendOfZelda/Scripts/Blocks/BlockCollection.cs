using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Blocks
{
    class BlockCollection : ICollection
    {
        private readonly List<IBlock> blockCollection = new List<IBlock>();
        private int currentObject = 0;

        public BlockCollection()
        {
            blockCollection.Add(BlockSpriteFactory.Instance.CreateBlueFloorSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateBlueSandSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreatePushBlockSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateStatueLeftSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateStatueRightSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateStairsSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateLadderSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateSquareBlockSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateWhiteBrickSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateBlueGapSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateFireBlockSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateEmptyWallFullLenSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateEmptyWallFullWidthSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateEmptyWallHalfWidthSprite());
            blockCollection.Add(BlockSpriteFactory.Instance.CreateEmptyWallHalfLenSprite());

        }

        public void Next()
        {
            currentObject = ++currentObject % blockCollection.Count;
        }

        public void Previous()
        {
            if (--currentObject < 0) { currentObject = blockCollection.Count - 1; }
        }

        public void Update(int scale)
        {
            blockCollection[currentObject].Update();
        }

        public IGameObject GameObject()
        {
            return blockCollection[currentObject];
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            blockCollection[currentObject].Draw(spriteBatch, scale);
        }
    }
}
