using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy
{
    public interface IEnemy //Should be IGameObject later
    {
        public Vector2 position { get; set; }

        public void Attack();

        public void Update();

        public void Draw(SpriteBatch spriteBatch);
    }
}
