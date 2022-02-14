using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Content.Input.Command;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Content.Controller
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private Game1 myGame;
        public KeyboardController(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            myGame = game;
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void Update()
        {
            bool moving = false;
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            
            controllerMappings[Keys.F].Execute();
            foreach (Keys key in keys)
            {
                controllerMappings[key].Execute();
            }
        }
    }
}
