namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class PreviousRoom : ICommand
    {
        private readonly Game1 myGame;
        public PreviousRoom(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.roomManager.PreviousRoom();
        }
    }
}