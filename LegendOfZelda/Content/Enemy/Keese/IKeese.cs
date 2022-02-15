using LegendOfZelda.Content.Enemy.Keese;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Keese
{
    public interface IKeese
    {
        IKeeseState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
