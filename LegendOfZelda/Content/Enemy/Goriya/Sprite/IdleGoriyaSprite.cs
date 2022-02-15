using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Content.Enemy.Goriya.Sprite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Goriya.Sprite
{
    class IdleGoriyaSprite : BasicGoriyaSprite
    {    
        public IdleGoriyaSprite(Texture2D texture, Vector2 Position)
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
            Random rnd = new Random();
            Pos = new Vector2(Pos.X, Pos.Y);
            CurrentFrame = (CurrentFrame + 1) % TotalFrames;
        }
    }
}

