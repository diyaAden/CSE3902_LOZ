using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Blocks.BlockSprites;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
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

        }
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side, int scale)
        {

        }
        public void HandleCollision(ILink link, IBlock door, RoomManager roomManager, int scale)
        {
            switch (door)
            {
                case StairsSprite _:
                    UseStairs(link, door, roomManager, scale);
                    break;
                case OpenDoorSpriteDown _:
                case OpenDoorSpriteUp _:
                case OpenDoorSpriteLeft _:
                case OpenDoorSpriteRight _:
                case BombedDoorSpriteDown _:
                case BombedDoorSpriteUp _:
                case BombedDoorSpriteLeft _:
                case BombedDoorSpriteRight _:
                    MoveThroughDoor(link, door, roomManager, scale);
                    break;
                case CrackedDoorSpriteDown _:
                case CrackedDoorSpriteUp _:
                case CrackedDoorSpriteLeft _:
                case CrackedDoorSpriteRight _:
                case LockedDoorSpriteDown _:
                case LockedDoorSpriteUp _:
                case LockedDoorSpriteLeft _:
                case LockedDoorSpriteRight _:
                    door.Disable();
                    break;
                default:
                    break;
            }
        }
        private void UseStairs(ILink link, IBlock stairs, RoomManager roomManager, int scale)
        {
            int currentRoom = roomManager.CurrentRoom;
            int newRoom = stairs.adjacentRoom;
            int direction;
            if (currentRoom == 17)
                direction = 4;
            else
                direction = 5;
            link.HandleDoorCollision(direction, scale);
            roomManager.CurrentRoom = newRoom;
        }
        private void MoveThroughDoor(ILink link, IBlock door, RoomManager roomManager, int scale)
        {
            int currentRoom = roomManager.CurrentRoom;
            int newRoom = door.adjacentRoom;
            int direction;
            if (currentRoom - newRoom > 1)
                direction = 0;
            else if (newRoom - currentRoom > 1)
                direction = 1;
            else if (currentRoom - newRoom == 1)
                direction = 2;
            else
                direction = 3;
            link.HandleDoorCollision(direction, scale);
            roomManager.CurrentRoom = newRoom;
        }
    }
}
