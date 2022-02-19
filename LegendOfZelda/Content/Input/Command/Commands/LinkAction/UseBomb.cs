using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Items.WeaponCreators;
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
        private static bool containsBomb(IWeapon weapon)
        {
            return weapon.GetWeaponType() == IWeapon.WeaponType.BOMB;
        }
        public void Execute()
        {
            if (!myGame.activeWeapons.Exists(containsBomb))
            {
                myGame.link.UseItem();
                IWeapon bomb = new BombWeapon(myGame.link.state.position, myGame.link.state.Direction);
                myGame.activeWeapons.Add(bomb);
            }
        }
    }
}
