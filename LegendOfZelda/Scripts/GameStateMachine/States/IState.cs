using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LegendOfZelda.Scripts.GameStateMachine.States
{
    public interface IState
    {
        public Vector2 position { get; set; }


        public void Update(int scale, Vector2 screenOffset);


        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}
