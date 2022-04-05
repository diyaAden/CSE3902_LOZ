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
        private KeyboardState oldKeyState;
        private List<Keys> movementKeys = new List<Keys> { Keys.A, Keys.W, Keys.D, Keys.S};
        private List<Keys> arrowKeys = new List<Keys> { Keys.Up, Keys.Down, Keys.Left, Keys.Right };
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
            KeyboardState keyState = Keyboard.GetState();
            Boolean isMoving = false;

            if (keys.Length == 0)
            {
                controllerMappings[Keys.F].Execute();
            }
            foreach (Keys key in keys)
            {
                if (movementKeys.Contains(key) && !isMoving){
                    controllerMappings[key].Execute();
                    isMoving = true;
                }
                else if (arrowKeys.Contains(key) && !isMoving) {
                    controllerMappings[key].Execute();
                    isMoving = true;
                }
                else if (controllerMappings.ContainsKey(key) && keyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key))
                {
                    controllerMappings[key].Execute();
                } 
            }
            oldKeyState = keyState;
            //isMoving = false;



        }
    }
}
