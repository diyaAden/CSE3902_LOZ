using LegendOfZelda.Content.Enemy.Goriya;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Goriya
{
    public interface IGoriya
    {
        IGoriyaState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
