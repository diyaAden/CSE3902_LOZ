using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.Sprite
{
    class LeftIdleLinkSprite: BasicLinkSprite
    {    
        public LeftIdleLinkSprite(Texture2D texture, Vector2 Position, bool damageState)
        {
            Rows = 1;
            Columns = 2;
            CurrentFrame = 1;
            TotalFrames = Rows * Columns;
            Texture = texture;
            Pos = Position;
            checkDamageState = damageState;
        }
        public override void Update()
        {
            CurrentFrame = CurrentFrame;
        }
    }
}

