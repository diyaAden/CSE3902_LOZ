using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands.LinkAction
{
    public class Attack : ICommand
    {
        private Game1 myGame;
        public Attack(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.link.state.Attack();
        }
    }
}
