using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Input.Combos
{
    public abstract class BasicCombo : ICombo
    {
        public List<Keys> ComboInputPattern { get; } = new List<Keys>();

        public Keys FinalKey()
        {
            return ComboInputPattern[^1];
        }

        public bool ComboIsComplete(List<Keys> keyHistory)
        {
            bool patternSatisfied = true;
            for (int i = 1; patternSatisfied && i <= ComboInputPattern.Count; i++)
            {
                if (!ComboInputPattern[^i].Equals(keyHistory[^i]))
                    patternSatisfied = false;
            }
            return patternSatisfied;
        }
    }
}
