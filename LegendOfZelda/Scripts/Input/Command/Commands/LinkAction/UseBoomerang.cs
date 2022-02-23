using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Items.WeaponCreators;
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
        private static bool containsBoomerang(IWeapon weapon)
        {
            return weapon.GetWeaponType() == IWeapon.WeaponType.BOOMERANG;
        }
        public void Execute()
        {
            if (!myGame.activeWeapons.Exists(containsBoomerang))
            {
                myGame.link.UseItem();
                IWeapon boomerang = new BoomerangWeapon(myGame.link.State.Position, myGame.link.State.Direction);
                myGame.activeWeapons.Add(boomerang);
            }
        }
    }
}
