namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class MaxRupeesCommand : ICommand
    {
        private readonly Game1 myGame;
        public MaxRupeesCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.link.numRupees = 99;
        }
    }
}