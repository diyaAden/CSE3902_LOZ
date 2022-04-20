namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class TeleportToNewLevelsCommand : ICommand
    {
        private readonly Game1 myGame;
        public TeleportToNewLevelsCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.roomManager.CurrentRoom = 19;
        }
    }
}