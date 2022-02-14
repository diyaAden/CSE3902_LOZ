using LegendOfZelda.Content.Enemy.Cloud;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.Cloud
{
    public interface ICloud
    {
        ICloudState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
