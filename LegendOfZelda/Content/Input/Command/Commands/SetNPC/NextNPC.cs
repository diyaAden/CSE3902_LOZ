﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class NextNPC : ICommand
    {
        private Game1 myGame;
        public NextNPC(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {

        }
    }
}