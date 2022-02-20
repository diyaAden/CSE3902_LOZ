using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links.Sprite
{
    class FrontAttackLinkSprite: BasicLinkSprite
    {    
        public FrontAttackLinkSprite(Texture2D texture, Vector2 Position, bool damageState)
        {
            Rows = 1;
            Columns = 3;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            Texture = texture;
            Pos = Position;
            checkDamageState = damageState;
            timer = 2;
        }
        public override void Update()
        {
            if (--timer == 0 && CurrentFrame != TotalFrames - 1)
            {
                ++CurrentFrame;
                timer = 2;
            }
        }
    }
}

