using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Items.WeaponCreators;
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
        private static bool containsMagicArrow(IWeapon weapon)
        {
            return weapon.GetWeaponType() == IWeapon.WeaponType.ARROW;
        }
        public void Execute()
        {
            if (!myGame.activeWeapons.Exists(containsMagicArrow))
            {
                myGame.link.state.UseItem();
                WeaponManager arrow = new MagicArrowWeapon(myGame.link.state.position, myGame.link.state.Direction);
                myGame.activeWeapons.Add(arrow);
            }
        }
    }
}
