using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class SetLinkIdle : ICommand
    {
        private Game1 myGame;
        public SetLinkIdle(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.link.ToIdle();
        }
    }
}
