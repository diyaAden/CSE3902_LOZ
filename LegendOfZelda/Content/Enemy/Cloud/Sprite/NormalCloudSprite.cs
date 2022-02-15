using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Content.Enemy.Cloud.Sprite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Cloud.Sprite
{
    class NormalCloudSprite : BasicCloudSprite
    {    
        public NormalCloudSprite(Texture2D texture, Vector2 Position)
        {
            Rows = 1;
            Columns = 4;
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

