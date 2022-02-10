using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class SetLinkUp : ICommand
    {
        private Game1 myGame;
        public SetLinkUp(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            //myGame.sprite = new MovSprite(myGame.LinkTexture, 700, 400);
        }
    }
}
