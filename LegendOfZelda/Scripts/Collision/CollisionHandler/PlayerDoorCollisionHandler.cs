using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    public class PlayerDoorCollisionHandler : ICollisionHandler
    {
        public PlayerDoorCollisionHandler()
        {
        }

        public void HandleCollision(ILink link, IEnemy enemy, ICollision side)
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
                    link.HandleItemCollision(gameObject, side);
                    break;
                default:
                    break;
            }
        }
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side, int scale)
        {

        }
    }
}
