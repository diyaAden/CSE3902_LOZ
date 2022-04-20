using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class GameStateStart : ICommand
    {
        private Game1 myGame;
        public GameStateStart(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Gstate = GameStateMachine.GameState.Start;
        }
    }
}