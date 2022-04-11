using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Links.Sprite
{
    class GameOverLinkSprite: BasicLinkSprite
    {
        const int timePerFrame = 8;
        public GameOverLinkSprite(Texture2D texture, Vector2 Position)
        {
            Rows = 1;
            Columns = 4;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
            Texture = texture;
            Pos = Position;
            Timer = 0;
            animationTimer = 0;

        }
        public override void Update()
        {
            if (++animationTimer % timePerFrame == 0)
            {
                CurrentFrame = ++CurrentFrame % Columns;
                if (animationTimer == (timePerFrame % 4))
                {
                    animationTimer = 0;
                    
                }
            }
            
        }
    }
}

