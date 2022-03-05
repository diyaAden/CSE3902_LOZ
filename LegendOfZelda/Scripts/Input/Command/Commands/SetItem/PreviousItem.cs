using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class PreviousItem : ICommand
    {
        private Game1 myGame;
        public PreviousItem(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.ItemCollection.Previous();
        }
    }
}