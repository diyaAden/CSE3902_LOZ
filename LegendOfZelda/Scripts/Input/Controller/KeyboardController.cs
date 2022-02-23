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
        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void Update()
        {
            Keys[] keys = Keyboard.GetState().GetPressedKeys();

            if (keys.Length == 0)
            {
                controllerMappings[Keys.F].Execute();
            }
            foreach (Keys key in keys)
            {
                if(controllerMappings.ContainsKey(key))
                controllerMappings[key].Execute();
            }
        }
    }
}
