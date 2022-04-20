using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Scripts.Input.Combos
{
    public class TeleportToNewLevels : BasicCombo
    {
        public TeleportToNewLevels()
        {
            ComboInputPattern.Add(Keys.P);
            ComboInputPattern.Add(Keys.P);
            ComboInputPattern.Add(Keys.P);
        }
    }
}
