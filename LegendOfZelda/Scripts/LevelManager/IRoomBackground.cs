using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public interface IRoomBackground
    {
        public Vector2 position { get; set; }

        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
