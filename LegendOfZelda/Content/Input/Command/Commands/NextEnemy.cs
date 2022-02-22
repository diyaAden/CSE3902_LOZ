using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    class NextEnemy : ICommand
    {
        private Game1 myGame;
        public NextEnemy(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.EnemyCollection.Next();
        }
    }
}
