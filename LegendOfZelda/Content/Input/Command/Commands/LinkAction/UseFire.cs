using LegendOfZelda.Content.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class UseFire : ICommand
    {
        private Game1 myGame;
        public UseFire(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.link.state.UseItem();
            WeaponManager fire = new WeaponManager(myGame.position);
            fire.BecomeFire(myGame.link.state.Direction);
            myGame.activeWeapons.Add(fire);
        }
    }
}
