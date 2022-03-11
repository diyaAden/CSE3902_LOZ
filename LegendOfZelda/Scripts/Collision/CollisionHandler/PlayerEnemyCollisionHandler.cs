using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    class PlayerEnemyCollisionHandler: ICollisionHandler
    {
        public void HandleCollision(ILink link, IEnemy enemy, ICollision side)
        {
            link.HandleEnemyCollision(enemy, side);
        }
        public void HandleCollision(ILink link, IGameObject gameObject, ICollision side, int scale)
        {
            
        }
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side, int scale)
        {

        }
    }

}
