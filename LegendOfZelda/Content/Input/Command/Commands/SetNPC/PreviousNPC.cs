using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class PreviousNPC : ICommand
    {
        private Game1 myGame;
        public PreviousNPC(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.EnemyCollection.Previous();
        }
    }
}