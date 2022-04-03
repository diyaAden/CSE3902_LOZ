using LegendOfZelda.Scripts.LevelManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Scripts.GameStateMachine
{
    public class RoomMovingController
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT, STAIRS, NONE }

        private Direction direction = Direction.NONE;
        private int newRoomNum, movedDist = 0;
        private readonly IRoomBackground blackFade;
        private readonly Vector2 roomDimensions = new Vector2(256, 176);
        private readonly RoomManager roomManager;
        private readonly int scale;
        private const int transitionSpeed = 2;
        public int CurrentRoom { 
            get { return roomManager.CurrentRoom; } 
            set { roomManager.CurrentRoom = value; } 
        }

        public RoomMovingController(RoomManager roomManager, int scale, Vector2 screenOffset)
        {
            this.roomManager = roomManager;
            this.scale = scale;
            roomDimensions = roomDimensions = new Vector2(roomDimensions.X * scale, roomDimensions.Y * scale);
            blackFade = RoomBackgroundFactory.Instance.CreateScreenFade();
            blackFade.Position = new Vector2(blackFade.Position.X + screenOffset.X * scale, blackFade.Position.Y + screenOffset.Y * scale);
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
                case Direction.STAIRS:
                    blackFade.Update();
                    if (!((BlackRoomFade)blackFade).FadeToBlack) CurrentRoom = newRoomNum;
                    if (((BlackRoomFade)blackFade).FadeDone) FinalizeRoomShift();
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (direction != Direction.STAIRS) roomManager.Rooms[newRoomNum].DrawBackgroundAndBlocks(spriteBatch, scale);
            roomManager.Rooms[roomManager.CurrentRoom].DrawBackgroundAndBlocks(spriteBatch, scale);
            blackFade.Draw(spriteBatch, scale);
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

        private void SetShiftCameraUp(int newRoomNum)
        {
            this.newRoomNum = newRoomNum;
            ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom(0, (int)-roomDimensions.Y, 1);
            direction = Direction.UP;
        }

        private void SetShiftCameraDown(int newRoomNum)
        {
            this.newRoomNum = newRoomNum;
            ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom(0, (int)roomDimensions.Y, 1);
            direction = Direction.DOWN;
        }

        private void SetShiftCameraLeft(int newRoomNum)
        {
            this.newRoomNum = newRoomNum;
            ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom((int)-roomDimensions.X, 0, 1);
            direction = Direction.LEFT;
        }

        private void SetShiftCameraRight(int newRoomNum)
        {
            this.newRoomNum = newRoomNum;
            ((Room)roomManager.Rooms[newRoomNum]).ShiftRoom((int)roomDimensions.X, 0, 1);
            direction = Direction.RIGHT;
        }
        private void StairsTransition(int newRoomNum)
        {
            this.newRoomNum = newRoomNum;
            ((BlackRoomFade)blackFade).Reset();
            direction = Direction.STAIRS;
        }
        public void ShiftCamera(int direction, int newRoomNum)
        {
            if (direction == 0) SetShiftCameraDown(newRoomNum);
            else if (direction == 1) SetShiftCameraUp(newRoomNum);
            else if (direction == 2) SetShiftCameraLeft(newRoomNum);
            else if (direction == 3) SetShiftCameraRight(newRoomNum);
            else StairsTransition(newRoomNum);
            GameStateController.Instance.SetGameStateRoomSwitch();
        }
    }
}
