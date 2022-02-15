using LegendOfZelda.Content.Enemy.WallMaster;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Enemy.WallMaster
{
    public interface IWallMaster
    {
        IWallMasterState state { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
