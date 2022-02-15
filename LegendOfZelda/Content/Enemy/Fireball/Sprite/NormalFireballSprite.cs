using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Content.Enemy.Explosion.Sprite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Fireball.Sprite
{
    class NormalFireballSprite : BasicFireballSprite
    {    
        public NormalFireballSprite(Texture2D texture, Vector2 Position)
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
            Pos = new Vector2(Pos.X + 2, Pos.Y + 2);
            CurrentFrame = (CurrentFrame + 1) % TotalFrames;
        }
    }
}

