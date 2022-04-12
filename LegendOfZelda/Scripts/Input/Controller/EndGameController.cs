using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Scripts.Input.Command;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Controller
{
    public class EndGameController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private Dictionary<int, ICommand> endGameCommand;

        private KeyboardState oldKeyState;
        private List<Keys> movementKeys = new List<Keys> { Keys.A, Keys.W, Keys.D, Keys.S};
        private List<Keys> arrowKeys = new List<Keys> { Keys.Up, Keys.Down, Keys.Left, Keys.Right };
        public EndGameController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            endGameCommand = new Dictionary<int, ICommand>();

        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void RegisterCommand(int i, ICommand command)
        {
            endGameCommand.Add(i, command);
        }
        public void Update()
        {

            
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            KeyboardState keyState = Keyboard.GetState();
            
            foreach (Keys key in keys)
            {
                
                if (controllerMappings.ContainsKey(key) && keyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key))
                {
                    controllerMappings[key].Execute();
                } 
            }
            oldKeyState = keyState;
        }
    }
}
