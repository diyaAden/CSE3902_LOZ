using LegendOfZelda.Scripts.Collision;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.Items
{
    public interface IGameObject
    {
        Rectangle ObjectBox(int scale);
        public void HandleCollision(ICollision side, int scale);
    }
}
