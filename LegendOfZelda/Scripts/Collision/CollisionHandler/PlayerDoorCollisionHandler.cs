using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Blocks.BlockSprites;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.GameStateMachine;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    public class PlayerDoorCollisionHandler : ICollisionHandler
    {
        public PlayerDoorCollisionHandler()
        {
        }

        public void HandleCollision(ILink link, IEnemy enemy, ICollision side, int scale, Vector2 screenOffset, int index, RoomManager roomManager)
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
        public void HandleCollision(ILink link, IBlock door, RoomManager roomManager, int scale) { }
        public void HandleCollision(ILink link, IBlock door, RoomMovingController roomMovingController, int scale)
        {
            switch (door)
            {
                case StairsSprite _:
                    UseStairs(link, door, roomMovingController, scale);
                    break;
                case OpenDoorSpriteDown _:
                case OpenDoorSpriteUp _:
                case OpenDoorSpriteLeft _:
                case OpenDoorSpriteRight _:
                case BombedDoorSpriteDown _:
                case BombedDoorSpriteUp _:
                case BombedDoorSpriteLeft _:
                case BombedDoorSpriteRight _:
                    MoveThroughDoor(link, door, roomMovingController, scale);
                    break;
                case LockedDoorSpriteDown _:
                case LockedDoorSpriteUp _:
                case LockedDoorSpriteLeft _:
                case LockedDoorSpriteRight _:
                    if (link.HasKeys()) door.Disable();
                    break;
                default:
                    break;
            }
        }
        private void UseStairs(ILink link, IBlock stairs, RoomMovingController roomMovingController, int scale)
        {
            int currentRoom = roomMovingController.CurrentRoom;
            int newRoom = stairs.AdjacentRoom;
            int direction;

            if (currentRoom == 17) direction = 4;
            else direction = 5;

            link.HandleDoorCollision(direction, scale);
            roomMovingController.ShiftCamera(direction, newRoom);
        }
        private void MoveThroughDoor(ILink link, IBlock door, RoomMovingController roomMovingController, int scale)
        {
            int currentRoom = roomMovingController.CurrentRoom;
            int newRoom = door.AdjacentRoom;
            int direction;
            if (currentRoom == 8 || currentRoom > 18)
            {
                if (newRoom == 20) direction = 2;
                else if (newRoom == 19 && currentRoom == 20) direction = 3;
                else if (newRoom == 19 && currentRoom == 8) direction = 2;
                else if (newRoom == 8 && currentRoom == 19) direction = 3;
                else if (newRoom == 9 && currentRoom == 8) direction = 2;
                else direction = 3;
                
            }
            else
            {
                if (currentRoom - newRoom > 1) direction = 0;
                else if (newRoom - currentRoom > 1) direction = 1;
                else if (currentRoom - newRoom == 1) direction = 2;
                else direction = 3;
            }
            Debug.WriteLine(newRoom);
            link.HandleDoorCollision(direction, scale);
            roomMovingController.ShiftCamera(direction, newRoom);
        }
    }
}
