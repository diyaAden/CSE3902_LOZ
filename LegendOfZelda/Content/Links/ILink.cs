using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Links
{
    public interface ILink
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
