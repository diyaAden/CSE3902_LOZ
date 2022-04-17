using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Combos
{
    public class ClearRoom : BasicCombo
    {
        public ClearRoom()
        {
            ComboInputPattern.Add(Keys.W);
            ComboInputPattern.Add(Keys.D);
            ComboInputPattern.Add(Keys.S);
            ComboInputPattern.Add(Keys.A);
            ComboInputPattern.Add(Keys.W);
            ComboInputPattern.Add(Keys.D);
            ComboInputPattern.Add(Keys.S);
            ComboInputPattern.Add(Keys.A);
        }
    }
}
