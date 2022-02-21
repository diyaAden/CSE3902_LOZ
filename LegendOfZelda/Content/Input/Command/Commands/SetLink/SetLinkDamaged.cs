using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class SetLinkDamaged : ICommand
    {
        private Game1 myGame;
        public SetLinkDamaged(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.link.State.toDamaged();
        }
    }
}
