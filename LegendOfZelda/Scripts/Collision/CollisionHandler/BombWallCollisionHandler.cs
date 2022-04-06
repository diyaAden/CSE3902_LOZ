using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Blocks.BlockSprites;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    public class BombWallCollisionHandler : ICollisionHandler
    {
        public BombWallCollisionHandler()
        {
        }

        public void HandleCollision(ILink link, IEnemy enemy, ICollision side)
        {
            
        }
        public void HandleCollision(ILink link, IGameObject gameObject, ICollision side, int scale)
        {

        }
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side, int scale)
        {

        }
        public void HandleItemDestroy(Room CurrentRoom, int index) { }
        public void HandleEnemyDestroy(Room CurrentRoom, int index) { }
        public void HandleCollision(ILink link, IBlock wall, RoomManager roomManager, int scale)
        {
            if (wall is SecretWallUpSprite || wall is SecretWallDownSprite || wall is SecretWallLeftSprite || wall is SecretWallRightSprite)
            {
                if (roomManager.CurrentRoom == 6 || roomManager.CurrentRoom == 10)
                {
                    roomManager.SecretPath6To10Open = true;
                }
                else if (roomManager.CurrentRoom == 7 || roomManager.CurrentRoom == 11)
                {
                    roomManager.SecretPath7To11Open = true;
                }
            }
        }
    }
}