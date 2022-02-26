using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy
{
    public interface IEnemy
    {
        public Vector2 position { get; set; }

        public void Attack();

        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
