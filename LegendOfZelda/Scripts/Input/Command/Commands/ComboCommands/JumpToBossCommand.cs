namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class JumpToBossCommand : ICommand
    {
        private readonly Game1 myGame;
        public JumpToBossCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.roomManager.CurrentRoom = 14;
        }
    }
}