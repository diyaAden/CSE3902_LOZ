using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;

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
            return weapon.GetWeaponType() == IWeapon.WeaponType.SWORDBEAM || weapon.GetWeaponType() == IWeapon.WeaponType.SWORDSHARDS;
        }
        public void Execute()
        {
            myGame.link.Attack(myGame.gameScale);
            if (!myGame.activeWeapons.Exists(containsSword))
            {
                IWeapon sword = new SwordWeapon(myGame.link.State.Position, myGame.link.State.Direction, myGame.gameScale);
                myGame.activeWeapons.Add(sword);
            }
        }
    }
}
