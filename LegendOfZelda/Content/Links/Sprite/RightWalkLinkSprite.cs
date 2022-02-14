﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.Sprite
{
    class RightWalkLinkSprite : BasicLinkSprite
    {
        public RightWalkLinkSprite(Texture2D texture, Vector2 Position, bool damageState)
        {
            Rows = 1;
            Columns = 2;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            Texture = texture;
            Pos = Position;
            checkDamageState = damageState;
        }
        public override void Update()
        {
            Pos = new Vector2(Pos.X + 3, Pos.Y);
            CurrentFrame = (CurrentFrame + 1) % TotalFrames;
        }
    }
}

