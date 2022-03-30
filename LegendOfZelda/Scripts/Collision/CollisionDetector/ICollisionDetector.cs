using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Collision.CollisionDetector
{
    public interface ICollisionDetector
    {
        List<ICollision> BoxTest(ILink link, IGameObject gameObject, int scale); //will let these functions together
        List<ICollision> BoxTest(IEnemy link, IGameObject gameObject, int scale);
        List<ICollision> BoxTest(ILink link, IEnemy enemy, int scale);
        List<ICollision> BoxTest(IWeapon weapon, IGameObject gameObject, int scale);
    }
}
