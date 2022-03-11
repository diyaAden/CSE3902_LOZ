using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Blocks.BlockSprites;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    public class PlayerGameObjectCollisionHandler: ICollisionHandler
    {
        public PlayerGameObjectCollisionHandler()
        {
        }

        public void HandleCollision(ILink link, IEnemy enemy, ICollision side)
        {
            
        }
        public void HandleCollision(ILink link, IGameObject gameObject, ICollision side, int scale)
        {
            switch (gameObject)
            {
                case PushBlockSprite _ :
                    gameObject.HandleCollision(side, scale);
                    link.HandleBlockCollision(gameObject, side);
                    break;
                case IBlock _ :
                    link.HandleBlockCollision(gameObject, side);
                    break;
                case IItem _ :
                    link.HandleItemCollision(gameObject, side);
                    break;
                case IWeapon weapon:
                    link.HandleWeaponCollision(gameObject, side);
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
