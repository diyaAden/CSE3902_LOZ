using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class NextRoom : ICommand
    {
        private Game1 myGame;
        public NextRoom(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.roomManager.CurrentRoom++;
        }
    }
}