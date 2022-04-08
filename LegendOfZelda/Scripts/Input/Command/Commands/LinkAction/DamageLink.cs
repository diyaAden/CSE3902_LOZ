﻿namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class DamageLink : ICommand
    {
        private readonly Game1 myGame;
        public DamageLink(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.HUDManager.damageLink();
        }
    }
}