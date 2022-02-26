using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class UseMagicBoomerang : ICommand
    {
        private Game1 myGame;
        public UseMagicBoomerang(Game1 game)
        {
            myGame = game;
        }
        private static bool containsBoomerang(IWeapon weapon)
        {
            return weapon.GetWeaponType() == IWeapon.WeaponType.BOOMERANG;
        }
        public void Execute()
        {
            if (!myGame.activeWeapons.Exists(containsBoomerang))
            {
                myGame.link.UseItem();
                WeaponManager boomerang = new MagicBoomerangWeapon(myGame.link.State.Position, myGame.link.State.Direction);
                myGame.activeWeapons.Add(boomerang);
            }
        }
    }
}
