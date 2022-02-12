using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.Sprite
{
    class FrontUseItemLinkSprite : BasicLinkSprite
    {    
        public FrontUseItemLinkSprite(Texture2D texture, Vector2 Position)
        {
            Rows = 1;
            Columns = 1;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            Texture = texture;
            Pos = Position;
        }
        public override void Update()
        {
            CurrentFrame = CurrentFrame;
        }
    }
}

