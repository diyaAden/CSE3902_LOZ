using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    class RoomBackgroundCollection : ICollection
    {
        private List<IRoomBackground> RoomCollection = new List<IRoomBackground>();
        private int currentObject = 0;

        public RoomBackgroundCollection()
        {
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateBlueFloorSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateBlueSandSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreatePushBlockSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateStatueLeftSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateStatueRightSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateStairsSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateLadderSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateSquareBlockSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateWhiteBrickSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateBlueGapSprite());
            //blockCollection.Add(BlockSpriteFactory.Instance.CreateFireBlockSprite());
        }

        public void Next()
        {
            //currentObject = ++currentObject % blockCollection.Count;
        }

        public void Previous()
        {
            //if (--currentObject < 0) { currentObject = blockCollection.Count - 1; }
        }

        public void Update()
        {
            //blockCollection[currentObject].Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //blockCollection[currentObject].Draw(spriteBatch);
        }
    }
}