using LegendOfZelda.Scripts.LevelManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.GameStateMachine
{
    public class RoomMovingController
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT, NONE }

        private Direction direction = Direction.NONE;
        private int newRoomNum;
        private Vector2 shiftedDist = new Vector2(0, 0);
        private int movedDist = 0;
        private readonly Vector2 roomDimensions = new Vector2(256, 176);
        private readonly RoomManager roomManager;
        private readonly int scale;
        private const int transitionSpeed = 2;
        public int CurrentRoom { 
            get { return roomManager.CurrentRoom; } 
            set { roomManager.CurrentRoom = value; } 
        }

        public RoomMovingController(RoomManager roomManager, int scale)
        {
            this.roomManager = roomManager;
            this.scale = scale;
            roomDimensions = roomDimensions = new Vector2(roomDimensions.X * scale, roomDimensions.Y * scale);
        }

        public void Update()
        {
            movedDist += transitionSpeed * scale;
            switch (direction)
            {
                case Direction.UP:
                    ((Room)roomManager.Rooms[roomManager.CurrentRoom]).ShiftRoom(0, transitionSpeed, scale);
                    ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom(0, transitionSpeed, scale);
                    if (movedDist == (int)roomDimensions.Y) FinalizeRoomShift();
                    break;
                case Direction.DOWN:
                    ((Room)roomManager.Rooms[roomManager.CurrentRoom]).ShiftRoom(0, -transitionSpeed, scale);
                    ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom(0, -transitionSpeed, scale);
                    if (movedDist == (int)roomDimensions.Y) FinalizeRoomShift();
                    break;
                case Direction.LEFT:
                    ((Room)roomManager.Rooms[roomManager.CurrentRoom]).ShiftRoom(transitionSpeed, 0, scale);
                    ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom(transitionSpeed, 0, scale);
                    if (movedDist == (int)roomDimensions.X) FinalizeRoomShift();
                    break;
                case Direction.RIGHT:
                    ((Room)roomManager.Rooms[roomManager.CurrentRoom]).ShiftRoom(-transitionSpeed, 0, scale);
                    ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom(-transitionSpeed, 0, scale);
                    if (movedDist == (int)roomDimensions.X) FinalizeRoomShift();
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            roomManager.Rooms[roomManager.CurrentRoom].DrawBackgroundAndBlocks(spriteBatch, scale);
            roomManager.Rooms[newRoomNum].DrawBackgroundAndBlocks(spriteBatch, scale);
        }

        private void FinalizeRoomShift()
        {
            if (direction == Direction.UP) ((Room)roomManager.Rooms[roomManager.CurrentRoom]).ShiftRoom(0, (int)-roomDimensions.Y, 1);
            else if (direction == Direction.DOWN) ((Room)roomManager.Rooms[roomManager.CurrentRoom]).ShiftRoom(0, (int)roomDimensions.Y, 1);
            else if (direction == Direction.LEFT) ((Room)roomManager.Rooms[roomManager.CurrentRoom]).ShiftRoom((int)-roomDimensions.X, 0, 1);
            else if (direction == Direction.RIGHT) ((Room)roomManager.Rooms[roomManager.CurrentRoom]).ShiftRoom((int)roomDimensions.X, 0, 1);
            CurrentRoom = newRoomNum;
            movedDist = 0;
            direction = Direction.NONE;
            GameStateController.Instance.SetGameStatePlaying();
        }

        public void SetShiftCameraUp(int newRoomNum)
        {
            this.newRoomNum = newRoomNum;
            ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom(0, (int)-roomDimensions.Y, 1);
            direction = Direction.UP;
        }

        public void SetShiftCameraDown(int newRoomNum)
        {
            this.newRoomNum = newRoomNum;
            ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom(0, (int)roomDimensions.Y, 1);
            direction = Direction.DOWN;
        }

        public void SetShiftCameraLeft(int newRoomNum)
        {
            this.newRoomNum = newRoomNum;
            ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom((int)-roomDimensions.X, 0, 1);
            direction = Direction.LEFT;
        }

        public void SetShiftCameraRight(int newRoomNum)
        {
            this.newRoomNum = newRoomNum;
            ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom((int)roomDimensions.X, 0, 1);
            direction = Direction.RIGHT;
        }
        public void ShiftCamera(int direction, int newRoomNum)
        {
            if (direction == 0) SetShiftCameraDown(newRoomNum);
            else if (direction == 1) SetShiftCameraUp(newRoomNum); 
            else if (direction == 2)  SetShiftCameraLeft(newRoomNum); 
            else SetShiftCameraRight(newRoomNum); 
        }
    }
}
