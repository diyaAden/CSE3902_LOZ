using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
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
            if (!myGame.activeWeapons.Exists(containsBomb) && myGame.link.hasBombs() && (myGame.link.CatchByEnemy == -1))
            {
                myGame.link.UseItem();
                IWeapon bomb = new BombWeapon(myGame.link.State.Position, myGame.link.State.Direction, myGame.gameScale);
                myGame.activeWeapons.Add(bomb);
            }
        }
    }
}
