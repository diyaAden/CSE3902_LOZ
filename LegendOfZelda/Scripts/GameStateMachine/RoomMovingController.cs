using LegendOfZelda.Scripts.LevelManager;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.GameStateMachine
{
    static class RoomMovingController
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT, NONE }

        private static Direction direction = Direction.NONE;
        private static RoomManager roomManager;
        private static int newRoomNum, transitionSpeed = 1;

        public static void Update()
        {
            switch (direction)
            {
                case Direction.UP:
                    break;
                default:
                    break;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {

        }

        public static void SetShiftCameraUp(RoomManager roomManager, int newRoomNum)
        {
            RoomMovingController.roomManager = roomManager;
            RoomMovingController.newRoomNum = newRoomNum;
            direction = Direction.UP;
        }

        public static void SetShiftCameraDown(RoomManager roomManager, int newRoomNum)
        {
            RoomMovingController.roomManager = roomManager;
            RoomMovingController.newRoomNum = newRoomNum;
            direction = Direction.DOWN;
        }

        public static void SetShiftCameraLeft(RoomManager roomManager, int newRoomNum)
        {
            RoomMovingController.roomManager = roomManager;
            RoomMovingController.newRoomNum = newRoomNum;
            direction = Direction.LEFT;
        }

        public static void SetShiftCameraRight(RoomManager roomManager, int newRoomNum)
        {
            RoomMovingController.roomManager = roomManager;
            RoomMovingController.newRoomNum = newRoomNum;
            direction = Direction.RIGHT;
        }
    }
}
