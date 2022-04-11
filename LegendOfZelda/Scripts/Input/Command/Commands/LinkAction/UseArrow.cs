using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
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
            if (!myGame.activeWeapons.Exists(containsArrow) && myGame.link.hasArrows() && (myGame.link.CatchByEnemy == -1))
            {
                myGame.link.UseItem();
                IWeapon arrow = new ArrowWeapon(myGame.link.State.Position, myGame.link.State.Direction, myGame.gameScale);
                myGame.activeWeapons.Add(arrow);
            }
        }
    }
}
