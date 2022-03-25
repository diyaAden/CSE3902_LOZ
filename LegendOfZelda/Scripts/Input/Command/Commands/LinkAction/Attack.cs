using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands.LinkAction
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
            return weapon.GetWeaponType() == IWeapon.WeaponType.SWORD || weapon.GetWeaponType() == IWeapon.WeaponType.SWORDSHARDS;
        }
        public void Execute()
        {
            myGame.link.Attack();
            if (!myGame.activeWeapons.Exists(containsSword))
            {
                IWeapon sword = new SwordWeapon(myGame.link.State.Position, myGame.link.State.Direction, myGame.gameScale);
                myGame.activeWeapons.Add(sword);
            }
        }
    }
}
