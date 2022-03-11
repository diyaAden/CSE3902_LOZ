﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Items.ItemSprites
{
    public class MagicArrowItemSprite : BasicItem
    {
        
        public MagicArrowItemSprite(Texture2D itemSpriteSheet)
        {
            spriteSheet = itemSpriteSheet;
            animationFrames.Add(new Rectangle(52, 16, 5, 16));
            name = "MagicArrow";
        }

        public override void Update()
        {
            
        }
    }
}
