using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
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
            if (myGame.link.CatchByEnemy == -1)
                myGame.link.State.ToDamaged();
        }
    }
}
