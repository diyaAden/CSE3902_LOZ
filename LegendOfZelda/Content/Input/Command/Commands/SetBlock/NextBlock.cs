using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class NextBlock : ICommand
    {
        private Game1 myGame;
        public NextBlock(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.BlockCollection.Next();
        }
    }
}