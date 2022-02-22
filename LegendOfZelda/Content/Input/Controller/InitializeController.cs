using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Content.Input.Command;
using LegendOfZelda.Content.Input.Command.Commands;
using LegendOfZelda.Content.Input.Command.Commands.LinkAction;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Content.Controller
{
    public class InitializeController
    {
        private Game1 myGame;
        public InitializeController(Game1 game)
        {
            myGame = game;
        }
        public void RegisterCommands(KeyboardController control)
        {
            //Game Controls
            control.RegisterCommand(Keys.Q, new QuitGame(myGame));
            control.RegisterCommand(Keys.R, new ResetGame(myGame));
            //KeyboardControls for Link
            control.RegisterCommand(Keys.A, new SetLinkLeft(myGame));
            control.RegisterCommand(Keys.D, new SetLinkRight(myGame));
            control.RegisterCommand(Keys.Left, new SetLinkLeft(myGame));
            control.RegisterCommand(Keys.Right, new SetLinkRight(myGame));
            control.RegisterCommand(Keys.W, new SetLinkUp(myGame));
            control.RegisterCommand(Keys.S, new SetLinkDown(myGame));
            control.RegisterCommand(Keys.Up, new SetLinkUp(myGame));
            control.RegisterCommand(Keys.Down, new SetLinkDown(myGame));
            control.RegisterCommand(Keys.X, new UseItem(myGame));
            control.RegisterCommand(Keys.M, new UseItem(myGame));
            control.RegisterCommand(Keys.Z, new Attack(myGame));
            control.RegisterCommand(Keys.N, new Attack(myGame));
            control.RegisterCommand(Keys.E, new SetLinkDamaged(myGame));
            control.RegisterCommand(Keys.F, new SetLinkIdle(myGame));
            control.RegisterCommand(Keys.D1, new UseBomb(myGame));
            control.RegisterCommand(Keys.NumPad1, new UseBomb(myGame));
            control.RegisterCommand(Keys.D2, new UseArrow(myGame));
            control.RegisterCommand(Keys.NumPad2, new UseArrow(myGame));
            control.RegisterCommand(Keys.D3, new UseMagicArrow(myGame));
            control.RegisterCommand(Keys.NumPad3, new UseMagicArrow(myGame));
            control.RegisterCommand(Keys.D4, new UseFire(myGame));
            control.RegisterCommand(Keys.NumPad4, new UseFire(myGame));
            control.RegisterCommand(Keys.D5, new UseBoomerang(myGame));
            control.RegisterCommand(Keys.NumPad5, new UseBoomerang(myGame));
            control.RegisterCommand(Keys.D6, new UseMagicBoomerang(myGame));
            control.RegisterCommand(Keys.NumPad6, new UseMagicBoomerang(myGame));
            //Block, enemy, and item controls
            control.RegisterCommand(Keys.T, new PreviousBlock(myGame));
            control.RegisterCommand(Keys.Y, new NextBlock(myGame));
            control.RegisterCommand(Keys.U, new PreviousItem(myGame));
            control.RegisterCommand(Keys.I, new NextItem(myGame));
        }
    }
}