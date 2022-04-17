using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Combos
{
    public class MaxRupees : BasicCombo
    {
        public MaxRupees()
        {
            ComboInputPattern.Add(Keys.D);
            ComboInputPattern.Add(Keys.D);
            ComboInputPattern.Add(Keys.D);
            ComboInputPattern.Add(Keys.D);
            ComboInputPattern.Add(Keys.D);
            ComboInputPattern.Add(Keys.W);
        }
    }
}
