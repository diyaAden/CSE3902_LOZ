﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class HeartContainerSprite : BasicItem
    {
        
        public HeartContainerSprite(Texture2D itemSpriteSheet, List<Rectangle> frames)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames = frames;
        }

        public override void Update()
        {
            
        }
    }
}
