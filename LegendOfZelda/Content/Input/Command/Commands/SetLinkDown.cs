using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class SetLinkDown : ICommand
    {
        private Game1 myGame;
        public SetLinkDown(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            //myGame.sprite = new MovAnimSprite(myGame.LinkTexture, 700, 400);
        }
    }
}
