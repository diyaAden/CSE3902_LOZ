using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class PreviousBlock : ICommand
    {
        private Game1 myGame;
        public PreviousBlock(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.BlockCollection.PreviousBlock();
        }
    }
}