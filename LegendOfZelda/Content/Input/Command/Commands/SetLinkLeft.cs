using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command
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
            //myGame.link = new SetLink(myGame.LinkTexture);
        }
    }
}
