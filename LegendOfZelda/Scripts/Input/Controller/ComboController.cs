using System.Collections.Generic;
using System.Diagnostics;
using LegendOfZelda.Scripts.Input.Combos;
using LegendOfZelda.Scripts.Input.Command;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Controller
{
    public class ComboController : IController
    {
        private readonly Dictionary<ICombo, ICommand> comboMappings = new Dictionary<ICombo, ICommand>();
        private readonly List<Keys> keyHistory = new List<Keys>();
        private bool keyPressed = false;
        private int longestComboPattern = 0;

        public ComboController() { }
        public void RegisterCommand(Keys key, ICommand command) { }
        public void RegisterCommand(ICombo combo, ICommand command)
        {
            comboMappings.Add(combo, command);
            if (combo.ComboInputPattern.Count > longestComboPattern)
                longestComboPattern = combo.ComboInputPattern.Count;
        }
        public void Update()
        {
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            if (keys.Length == 1 && !keyPressed)
            {
                keyPressed = true;
                UpdateKeyHistory(keys[0]);
                SearchForCombo();
            }
            else if (keys.Length == 0) keyPressed = false;
        }
        private void UpdateKeyHistory(Keys key)
        {
            keyHistory.Add(key);
            while (keyHistory.Count > longestComboPattern) 
                keyHistory.RemoveAt(0);
        }
        private void SearchForCombo()
        {
            foreach (ICombo combo in comboMappings.Keys)
            {
                if (keyHistory.Count >= combo.ComboInputPattern.Count && keyHistory[keyHistory.Count - 1].Equals(combo.FinalKey()))
                {
                    if (combo.ComboIsComplete(keyHistory)) comboMappings.GetValueOrDefault(combo).Execute();
                }
            }
        }
    }
}
