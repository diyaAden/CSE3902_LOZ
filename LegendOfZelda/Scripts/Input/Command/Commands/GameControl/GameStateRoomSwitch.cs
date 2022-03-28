using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class GameStateRoomSwitch : ICommand
    {
        private Game1 myGame;
        public GameStateRoomSwitch(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Gstate = GameStateMachine.GameState.RoomSwitch;
        }
    }
}