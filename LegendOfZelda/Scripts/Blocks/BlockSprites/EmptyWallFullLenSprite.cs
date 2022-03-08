﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class EmptyWallFullLenSprite: BasicBlock
    {
        public EmptyWallFullLenSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(1, 11, 200, 16);
        }

        public override void Update()
        {

        }
    }
    
}
