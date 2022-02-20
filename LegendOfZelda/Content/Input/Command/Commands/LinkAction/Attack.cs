using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Items.WeaponCreators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands.LinkAction
{
    public class Attack : ICommand
    {
        private Game1 myGame;
        public Attack(Game1 game)
        {
            myGame = game;
        }
        private static bool containsSword(IWeapon weapon)
        {
            return weapon.GetWeaponType() == IWeapon.WeaponType.SWORD;
        }
        public void Execute()
        {
            myGame.link.Attack();
            /* Must fix link attacking
            if (!myGame.activeWeapons.Exists(containsSword))
            {
                IWeapon sword = new SwordWeapon(myGame.link.state.position, myGame.link.state.Direction);
                myGame.activeWeapons.Add(sword);
            }
            */
        }
    }
}
