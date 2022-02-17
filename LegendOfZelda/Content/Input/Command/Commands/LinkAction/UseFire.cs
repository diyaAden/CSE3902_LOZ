using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Items.WeaponCreators;
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
        private static bool containsFire(IWeapon weapon)
        {
            return weapon.GetWeaponType() == IWeapon.WeaponType.Fire;
        }
        public void Execute()
        {
            if (!myGame.activeWeapons.Exists(containsFire))
            {
                myGame.link.state.UseItem();
                IWeapon fire = new FireWeapon(myGame.link.state.position, myGame.link.state.Direction);
                myGame.activeWeapons.Add(fire);
            }
        }
    }
}
