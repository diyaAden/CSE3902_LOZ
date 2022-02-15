using LegendOfZelda.Content.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class UseBoomerang : ICommand
    {
        private Game1 myGame;
        public UseBoomerang(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.link.state.UseItem();
            WeaponManager boomerang = new WeaponManager(myGame.link.state.position);
            boomerang.BecomeBoomerang(myGame.link.state.Direction);
            myGame.activeWeapons.Add(boomerang);
        }
    }
}
