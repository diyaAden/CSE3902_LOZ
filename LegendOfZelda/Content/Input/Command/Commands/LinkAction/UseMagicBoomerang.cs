﻿using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Items.WeaponCreators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
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
                WeaponManager boomerang = new MagicBoomerangWeapon(myGame.link.state.position, myGame.link.state.Direction);
                myGame.activeWeapons.Add(boomerang);
            }
        }
    }
}