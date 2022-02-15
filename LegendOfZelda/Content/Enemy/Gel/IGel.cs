using LegendOfZelda.Content.Enemy.Gel;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Gel
{
    public interface IGel
    {
        IGelState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
