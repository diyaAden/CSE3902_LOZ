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
        public void SetGameStatePausing()
        {
            ICommand command = new GameStatePausing(myGame);
            command.Execute();
        }

        public void SetGameStateStart()
        {
            ICommand command = new GameStateStart(myGame);
            command.Execute();
        }
        public void SetGameStateItemSelection()
        {
            ICommand command = new GameStateItemSelection(myGame);
            command.Execute();
        }
        public void SetGameStateGameOver()
        {
            ICommand command = new GameStateGameOver(myGame);
            command.Execute();
        }

        public void SetGameStateWonGame()
        {
            ICommand command = new GameStateWonGame(myGame);
            command.Execute();
        }
    }
}
