using LegendOfZelda.Content.Enemy.Aquamentus;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Aquamentus
{
    public interface IAquamentus
    {
        IAquamentusState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
