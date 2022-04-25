using LegendOfZelda.Scripts.Input.Command.Commands.LinkAction;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.ItemSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Input.Command.Commands
{
    public class UseItem : ICommand
    {
        private Game1 myGame;
        public UseItem(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            if (myGame.link.CatchByEnemy == -1)
            {
                UseCurrentItem(myGame.HUD.HUD.invDisplayItems[myGame.HUD.HUD.currentItem]);
                //myGame.HUD.HUD.currentItem = ++myGame.HUD.HUD.currentItem % myGame.HUD.HUD.invDisplayItems.Count;
            }
        }
        private void UseCurrentItem(IItem item)
        {
            ICommand command;
            switch (item)
            {
                case BombItemSprite _:
                    myGame.link.UseItem();
                    command = new UseBomb(myGame);
                    command.Execute();
                    break;
                case BowSprite _:
                    myGame.link.UseItem();
                    command = new UseArrow(myGame);
                    command.Execute();
                    break;
                case WoodBoomerangItemSprite _:
                    myGame.link.UseItem();
                    command = new UseBoomerang(myGame);
                    command.Execute();
                    break;
                case MagicBoomerangItemSprite _:
                    myGame.link.UseItem();
                    command = new UseMagicBoomerang(myGame);
                    command.Execute();
                    break;
                case SwordItemSprite _:
                    command = new Attack(myGame);
                    command.Execute();
                    break;
            }
        }
    }
}
