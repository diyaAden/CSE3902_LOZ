using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    class EnemyGameObjectCollisionHandler: ICollisionHandler
    {
        public EnemyGameObjectCollisionHandler()
        {
        }

        public void HandleCollision(ILink link, IEnemy enemy, ICollision side, int scale, Vector2 screenOffset, int index)
        {
            
        }
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side, int scale)
        {
            switch (gameObject)
            {
                case IBlock _:
                    if (enemy.IsCollisionWithLink == false)
                    {
                        enemy.HandleBlockCollision(gameObject, side, scale);
                    }
                    break;
                case IWeapon _:
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
        public void HandleItemDestroy(Room CurrentRoom, int index) { }

        public void HandleEnemyDestroy(Room CurrentRoom, int index)
        {
            CurrentRoom.RemoveObject("Enemy", index);
        }
    }
}
