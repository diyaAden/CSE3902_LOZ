using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class PreviousRoom : ICommand
    {
        private Game1 myGame;
        public PreviousRoom(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.roomManager.CurrentRoom--;
        }
    }
}