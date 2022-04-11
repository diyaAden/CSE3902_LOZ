using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    public class PlayerGameObjectCollisionHandler: ICollisionHandler
    {
        public PlayerGameObjectCollisionHandler()
        {
        }

        public void HandleCollision(ILink link, IEnemy enemy, ICollision side, int scale, Vector2 screenOffset, int index)
        {
            
        }
        public void HandleCollision(ILink link, IGameObject gameObject, ICollision side, int scale)
        {
            switch (gameObject)
            {
                case IBlock _ :
                    gameObject.HandleCollision(side, scale);
                    link.HandleBlockCollision(gameObject, side);
                    
                    break;
                case IItem _ :
                    link.HandleItemCollision(gameObject, side, scale);
                  //  link.addInventoryItem(gameObject);
                    break;
                case IWeapon _:
                    link.HandleWeaponCollision(gameObject, side);
                   // link.addInventoryItem(gameObject);
                    break;
                default:
                    break;
            }
        }
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side, int scale)
        {

        }
        public void HandleCollision(ILink link, IBlock door, RoomManager roomManager, int scale) { }

        public void HandleItemDestroy(Room CurrentRoom, int index)
        {
            CurrentRoom.RemoveObject("Item", index);
        }
        public void HandleEnemyDestroy(Room CurrentRoom, int index) { }
    }
}
