using LegendOfZelda.Scripts.GameStateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class GameStatePausing : ICommand
    {
        private Game1 myGame;
        public GameStatePausing(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.HUD.TogglePause();
            myGame.Gstate = GameState.Pausing;
        }
    }
}