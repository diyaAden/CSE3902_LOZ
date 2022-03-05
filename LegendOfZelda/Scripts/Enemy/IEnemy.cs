using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Scripts.Collision;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.Enemy
{
    public interface IEnemy //Should be IGameObject later
    {
        public Vector2 position { get; set; }

        public void Attack();
        void HandleItemCollision(IGameObject item, ICollision side);

        public void Update();

        public Rectangle ObjectBox();

        public void Draw(SpriteBatch spriteBatch);
    }
}
