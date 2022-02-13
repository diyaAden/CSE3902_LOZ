﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Content.Items.ItemSprites
{
    public class CompassSprite : BasicItem
    {
        
        public CompassSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(258, 1, 11, 12));
        }

        public override void Update()
        {
            
        }
    }
}
