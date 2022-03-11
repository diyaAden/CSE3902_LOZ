
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionDetector
{
    class CollisionPlayerDoorDetector: ICollisionDetector
    {
        public List<ICollision> BoxTest(IEnemy link, IGameObject gameObject, int scale)
        {
            return null;
        }
        public List<ICollision> BoxTest(ILink link, IGameObject gameObject, int scale)
        {
            List<ICollision> sides = new List<ICollision>();
            Rectangle linkBox = link.State.LinkBox(scale);
            Rectangle CheckSide = Rectangle.Intersect(linkBox, gameObject.ObjectBox(scale));
            if (!CheckSide.IsEmpty)
            {
                sides.Add(ICollision.SideNone);
            }
            return sides;
        }

        public List<ICollision> BoxTest(ILink link, IEnemy enemy, int scale)
        {
            return null;
        }
    }
}
