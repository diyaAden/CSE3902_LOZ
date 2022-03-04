using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Scripts.Input.Command;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Controller
{
    public class MouseController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private int frame = 0;
        private Keys lastKey;
        
        private Queue<Keys> previousKeys = new Queue<Keys>();
        public MouseController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void Update()
        {
            MouseState mouse = Mouse.GetState();
            if (frame == 3)
            {
                frame = 0;
            }
            if (mouse.RightButton == ButtonState.Pressed && frame == 2)
            {
                controllerMappings[Keys.F11].Execute();
            }
            else if (mouse.LeftButton == ButtonState.Pressed && frame == 1)
            {
                controllerMappings[Keys.F12].Execute();
            }
            else
            {
                frame++;
            }

        }
    }
}
