﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Content.Blocks.BlockSprites
{
    class StatueLeftSprite : BasicBlock
    {
        public StatueLeftSprite(Texture2D blockSpriteSheet)
        {
            spriteSheet = blockSpriteSheet;
            sourceRect = new Rectangle(52, 11, 16, 16);
        }

        public override void Update()
        {
            
        }
    }
}
