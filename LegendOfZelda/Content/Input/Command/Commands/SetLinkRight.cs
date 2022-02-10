using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class SetLinkRight : ICommand
    {
        private Game1 myGame;
        public SetLinkRight(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            //myGame.sprite = new LinkMovingRight(myGame.LinkTexture);
        }
    }
}
