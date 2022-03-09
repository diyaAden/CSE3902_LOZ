using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Scripts.Input.Command;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Controller
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private int frame = 0;
        private Keys lastKey;
        private Queue<Keys> previousKeys = new Queue<Keys>();
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
                if (frame == 3 && previousKeys.Count > 0)
                {
                    previousKeys.Dequeue();
                    frame = 0;
                }
                if (controllerMappings.ContainsKey(key) && !previousKeys.Contains(key))
                {
                    controllerMappings[key].Execute();
                    previousKeys.Enqueue(key);
                }
                frame++;
            }
            
            
        }
    }
}
