using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    public interface ICollisionHandler
    {
        void HandleCollision(ILink link, IGameObject gameObject, ICollision side);
        void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side);
    }
}
