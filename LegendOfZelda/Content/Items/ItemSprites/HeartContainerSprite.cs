﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class HeartContainerSprite : BasicItem
    {
        
        public HeartContainerSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(25, 1, 13, 13));
        }

        public override void Update()
        {
            
        }
    }
}
