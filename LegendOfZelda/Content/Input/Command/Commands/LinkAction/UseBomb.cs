using LegendOfZelda.Content.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class UseBomb : ICommand
    {
        private Game1 myGame;
        public UseBomb(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.link.state.UseItem();
            WeaponManager bomb = new WeaponManager(myGame.position);
            bomb.BecomeBomb(myGame.link.Direction);
            myGame.activeWeapons.Add(bomb);
        }
    }
}
