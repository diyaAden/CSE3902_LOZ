using LegendOfZelda.Content.Enemy.Explosion;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Explosion
{
    public interface IExplosion
    {
        IExplosionState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
