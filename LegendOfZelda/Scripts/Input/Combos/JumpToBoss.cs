using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Combos
{
    public class JumpToBoss : BasicCombo
    {
        public JumpToBoss() 
        {
            ComboInputPattern.Add(Keys.W);
            ComboInputPattern.Add(Keys.W);
            ComboInputPattern.Add(Keys.S);
            ComboInputPattern.Add(Keys.S);
            ComboInputPattern.Add(Keys.A);
            ComboInputPattern.Add(Keys.D);
            ComboInputPattern.Add(Keys.A);
            ComboInputPattern.Add(Keys.D);
        }
    }
}
