using LegendOfZelda.Content.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class UseMagicArrow : ICommand
    {
        private Game1 myGame;
        public UseMagicArrow(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.link.state.UseItem();
            WeaponManager arrow = new WeaponManager(myGame.position);
            arrow.BecomeMagicArrow(myGame.link.state.Direction);
            myGame.activeWeapons.Add(arrow);
        }
    }
}
