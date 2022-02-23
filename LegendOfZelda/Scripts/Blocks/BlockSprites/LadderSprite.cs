﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Blocks.BlockSprites
{
    class LadderSprite : BasicBlock
    {
        public LadderSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(18, 45, 16, 16);
        }

        public override void Update()
        {
            
        }
    }
}