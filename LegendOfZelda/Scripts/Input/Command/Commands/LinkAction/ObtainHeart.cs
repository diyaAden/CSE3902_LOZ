namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class ObtainHeart : ICommand
    {
        private readonly Game1 myGame;
        public ObtainHeart(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.HUDManager.gainHeart();
        }
    }
}