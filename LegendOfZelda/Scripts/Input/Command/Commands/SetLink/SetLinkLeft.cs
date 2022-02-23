using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class SetLinkLeft : ICommand
    {
        private Game1 myGame;
        public SetLinkLeft(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.link.MoveLeft();
        }
    }
}
