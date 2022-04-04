using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Scripts.Input.Command;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Controller
{
    public class GamepadController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private int frame = 0;
        private Keys lastKey;
        private MouseState oldState;
        
        private Queue<Keys> previousKeys = new Queue<Keys>();
        public GamepadController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void Update()
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (capabilities.IsConnected) {
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                if(state.ThumbSticks.Left.X < -0.5f)
                {
                    controllerMappings[Keys.A].Execute();
                }
                if(state.ThumbSticks.Left.X > 0.5f) {
                    controllerMappings[Keys.D].Execute();
                }
                if(state.ThumbSticks.Left.Y < -0.5f)
                {
                    controllerMappings[Keys.S].Execute();
                }
                if(state.ThumbSticks.Left.Y > 0.5f)
                {
                    controllerMappings[Keys.W].Execute();
                }
                if(capabilities.GamePadType == GamePadType.GamePad)
                {
                    if (state.IsButtonDown(Buttons.B)) {
                        controllerMappings[Keys.Z].Execute();
                    }
                    if (state.IsButtonDown(Buttons.B)) {
                        controllerMappings[Keys.X].Execute();
                    }

                }
            }

        }
    }
}
