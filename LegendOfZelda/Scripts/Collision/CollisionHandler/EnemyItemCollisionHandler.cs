using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    class EnemyItemCollisionHandler: ICollisionHandler
    {
        public EnemyItemCollisionHandler()
        {
        }
        public void HandleCollision(IEnemy enemy, IGameObject item, ICollision side)
        {
            enemy.HandleItemCollision(item, side);
        }
        public void HandleCollision(ILink link, IGameObject gameObject, ICollision side)
        {

        }
    }
}
