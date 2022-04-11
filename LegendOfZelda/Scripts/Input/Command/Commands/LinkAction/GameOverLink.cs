using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Input.Command.Commands.LinkAction
{
    public class GameOverLink : ICommand
    {
        private Game1 myGame;
        public GameOverLink(Game1 game)
        {
            myGame = game;
        }
        
        public void Execute()
        {
            myGame.link.GameOverLink();
        }
    }
}
