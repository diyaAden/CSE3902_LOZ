namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class NextRoom : ICommand
    {
        private readonly Game1 myGame;
        public NextRoom(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.roomManager.NextRoom();
        }
    }
}