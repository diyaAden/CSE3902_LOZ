using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Input.Combos
{
    public abstract class BasicCombo : ICombo
    {
        public List<Keys> ComboInputPattern { get; } = new List<Keys>();
        private int completedKeys = -1;

        public Keys FinalKey()
        {
            return ComboInputPattern[ComboInputPattern.Count - 1];
        }

        public bool ComboIsComplete(List<Keys> keyHistory)
        {
            bool patternSatisfied = true;
            for (int i = 1; patternSatisfied && i <= ComboInputPattern.Count; i++)
            {
                if (!ComboInputPattern[ComboInputPattern.Count - i].Equals(keyHistory[keyHistory.Count - i]))
                    patternSatisfied = false;
            }
            return patternSatisfied;
        }
    }
}
