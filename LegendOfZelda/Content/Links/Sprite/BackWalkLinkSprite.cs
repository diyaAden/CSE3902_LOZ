﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.Sprite
{
    class BackWalkLinkSprite: BasicLinkSprite
    {    
        public BackWalkLinkSprite(Texture2D texture, Vector2 Position, bool damageState)
        {
            Rows = 1;
            Columns = 2;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            Texture = texture;
            Pos = Position;
            checkDamageState = damageState;
            timer = 20;
        }
        public override void Update()
        {
            timer--;
            Pos = new Vector2(Pos.X, Pos.Y - 3);
            if (timer == 0)
            {
                CurrentFrame = (CurrentFrame + 1) % TotalFrames;
                timer = 20;
            }
        }
    }
}

