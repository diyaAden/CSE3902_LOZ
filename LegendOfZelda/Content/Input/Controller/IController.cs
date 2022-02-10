using System;
using System.Collections.Generic;
using System.Text;
using LegendOfZelda.Content.Input.Command;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Content.Controller
{
    public interface IController
    {
        void Update();
        void RegisterCommand(Keys key, ICommand command);
    }
}
