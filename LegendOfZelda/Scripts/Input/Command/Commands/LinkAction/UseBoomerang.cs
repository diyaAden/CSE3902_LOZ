using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
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
                Rectangle linkBox = myGame.link.State.LinkBox(myGame.gameScale);
                Vector2 linkCenter = new Vector2(linkBox.X + linkBox.Width / 2f, linkBox.Y + linkBox.Height / 2f);
                myGame.link.UseItem();
                IWeapon boomerang = new BoomerangWeapon(linkCenter, myGame.link.State.Direction);
                myGame.activeWeapons.Add(boomerang);
            }
        }
    }
}
