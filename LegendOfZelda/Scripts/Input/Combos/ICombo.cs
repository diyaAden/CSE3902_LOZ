using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Input.Combos
{
    public interface ICombo
    {
        public List<Keys> ComboInputPattern { get; }
        public Keys FinalKey();
        public bool ComboIsComplete(List<Keys> keyHistory);
    }
}
