using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class NextItem : ICommand
    {
        private Game1 myGame;
        public NextItem(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.ItemCollection.Next();
        }
    }
}