using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class ResetGame : ICommand
    {
        private Game1 myGame;
        public ResetGame(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            //myGame.
        }
    }
}