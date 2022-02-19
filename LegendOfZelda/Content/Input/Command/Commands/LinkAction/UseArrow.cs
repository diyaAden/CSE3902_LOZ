using LegendOfZelda.Content.Items;
using LegendOfZelda.Content.Items.WeaponCreators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Content.Input.Command.Commands
{
    public class UseArrow : ICommand
    {
        private Game1 myGame;
        public UseArrow(Game1 game)
        {
            myGame = game;
        }
        private static bool containsArrow(IWeapon weapon)
        {
            return weapon.GetWeaponType() == IWeapon.WeaponType.ARROW;
        }
        public void Execute()
        {
            if (!myGame.activeWeapons.Exists(containsArrow))
            {
                myGame.link.UseItem();
                IWeapon arrow = new ArrowWeapon(myGame.link.state.position, myGame.link.state.Direction);
                myGame.activeWeapons.Add(arrow);
            }
        }
    }
}
