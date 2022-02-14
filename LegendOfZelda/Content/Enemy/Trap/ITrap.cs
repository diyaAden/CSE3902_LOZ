using LegendOfZelda.Content.Enemy.Trap;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Trap
{
    public interface ITrap
    {
        ITrapState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
