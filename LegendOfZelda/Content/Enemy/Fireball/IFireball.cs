using LegendOfZelda.Content.Enemy.Fireball;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Fireball
{
    public interface IFireball
    {
        IFireballState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
