using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.HUDandInventoryManager
{
    public interface IHUDItem
    {
        public string name { get; set; }

        public Vector2 Position { get; set; }

        public void Update();

        public void Draw(SpriteBatch spriteBatch, int scale, Vector2 offset);
    }
}
