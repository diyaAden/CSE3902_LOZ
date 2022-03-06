using LegendOfZelda.Scripts.Blocks;
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
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side)
        {
            switch (gameObject)
            {
                case IBlock block:
                    enemy.HandleBlockCollision(gameObject, side);
                    break;
                case IWeapon weapon:
                    enemy.HandleWeaponCollision(gameObject, side);
                    break;
                default:
                    break;
            }
        }
        public void HandleCollision(ILink link, IGameObject gameObject, ICollision side)
        {

        }
    }
}
