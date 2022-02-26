using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Scripts.Input.Command;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Controller
{
    public interface IController
    {
        void Update();
        void RegisterCommand(Keys key, ICommand command);
    }
}
