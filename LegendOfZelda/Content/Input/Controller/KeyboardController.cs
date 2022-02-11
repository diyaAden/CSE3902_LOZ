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
            KeyboardState state = Keyboard.GetState();


            if (state.IsKeyDown(Keys.A))
            {
                controllerMappings[Keys.A].Execute();
                Console.WriteLine("Here");
            }else if(state.IsKeyDown(Keys.D)){
                controllerMappings[Keys.D].Execute();
            }
        }
    }
}
