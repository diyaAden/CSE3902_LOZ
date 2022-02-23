﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
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
            myGame.link.MoveDown();
        }
    }
}