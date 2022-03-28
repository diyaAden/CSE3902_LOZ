using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.HUD
{
    public interface IHUDAppearance
    {
        public Vector2 position { get; set; }

        

        public void Update();


        public void Draw(SpriteBatch spriteBatch);


    }
}
