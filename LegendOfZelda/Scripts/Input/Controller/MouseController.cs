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
        private MouseState oldState;
        
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
            MouseState newState = Mouse.GetState();
            if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
                controllerMappings[Keys.K].Execute();
            }
            else if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                controllerMappings[Keys.L].Execute();
            }
            else
            {
               // Mouse.SetPosition(400, 500);
            }
            oldState = newState;
        }
    }
}
