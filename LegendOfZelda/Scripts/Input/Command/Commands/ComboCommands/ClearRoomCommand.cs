using LegendOfZelda.Scripts.LevelManager;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class ClearRoomCommand : ICommand
    {
        private readonly Game1 myGame;
        public ClearRoomCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            Room room = (Room)myGame.roomManager.Rooms[myGame.roomManager.CurrentRoom];
            while (room.Enemies.Count > 1)
                room.RemoveObject("Enemy", 1);
        }
    }
}