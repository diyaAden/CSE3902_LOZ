using LegendOfZelda.Scripts.Input.Command;
using LegendOfZelda.Scripts.Input.Command.Commands;

namespace LegendOfZelda.Scripts.GameStateMachine
{
    public class GameStateController
    {
        private Game1 myGame;
        private static readonly GameStateController instance = new GameStateController();
        public static GameStateController Instance => instance;

        public GameStateController() { }
        public void LoadGame(Game1 game)
        {
            myGame = game;
        }
        public void SetGameStateRoomSwitch()
        {
            ICommand command = new GameStateRoomSwitch(myGame);
            command.Execute();
        }
        public void SetGameStatePlaying()
        {
            ICommand command = new GameStatePlaying(myGame);
            command.Execute();
        }
    }
}
