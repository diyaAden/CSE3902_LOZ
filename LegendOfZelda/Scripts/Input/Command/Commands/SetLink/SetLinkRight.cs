﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
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
            if (myGame.link.CatchByEnemy == -1)
                myGame.link.MoveRight();
        }
    }
}
