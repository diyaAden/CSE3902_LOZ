using LegendOfZelda.Content.Enemy.Stalfos;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Stalfos
{
    public interface IStalfos
    {
        IStalfosState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
