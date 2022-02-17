﻿using LegendOfZelda.Content.Items;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Blocks
{
    class BlockCollection
    {
        private List<IBlock> blocks;
        private int currentBlock = 0;

        public BlockCollection()
        {
            blocks = new List<IBlock>();
            blocks.Add(BlockSpriteFactory.Instance.CreateBlueFloorSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateBlueSandSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreatePushBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateStatueLeftSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateStatueRightSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateStairsSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateLadderSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateSquareBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateWhiteBrickSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateBlueGapSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateFireBlockSprite());
        }

        public void NextBlock()
        {
            currentBlock = ++currentBlock % blocks.Count;
        }

        public void PreviousBlock()
        {
            if (--currentBlock < 0)
            {
                currentBlock = blocks.Count - 1;
            }
        }

        public void Update()
        {
            blocks[currentBlock].Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blocks[currentBlock].Draw(spriteBatch);
        }
    }
}
