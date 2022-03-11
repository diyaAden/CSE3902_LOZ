using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    class EnemyGameObjectCollisionHandler: ICollisionHandler
    {
        public EnemyGameObjectCollisionHandler()
        {
        }

        public void HandleCollision(ILink link, IEnemy enemy, ICollision side)
        {
            
        }
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side, int scale)
        {
            switch (gameObject)
            {
                case IBlock block:
                    enemy.HandleBlockCollision(gameObject, side, scale);
                    break;
                case IWeapon weapon:
                    enemy.HandleWeaponCollision(gameObject, side);
                    break;
                default:
                    break;
            }
        }
        public void HandleCollision(ILink link, IGameObject gameObject, ICollision side, int scale)
        {

        }
        public void HandleCollision(ILink link, IBlock door, RoomManager roomManager, int scale) { }
    }
}
