
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace LegendOfZelda.Scripts.Collision.CollisionDetector
{
    class CollisionPlayerEnemyDetector: ICollisionDetector
    {
        public List<ICollision> BoxTest(IEnemy link, IGameObject gameObject, int scale)
        {
            return null;
        }
        public List<ICollision> BoxTest(ILink link, IGameObject gameObject, int scale)
        {
            return null;
        }

        public List<ICollision> BoxTest(ILink link, IEnemy enemy, int scale)
        {
            List<ICollision> sides = new List<ICollision>();
            Rectangle linkBox = link.State.LinkBox(scale);
            Rectangle CheckSide = Rectangle.Intersect(linkBox, enemy.ObjectBox());
            if (CheckSide.IsEmpty)
            {
                sides.Add(ICollision.SideNone);
            }
            else
            {
                float LeftRightCheck = CheckSide.Center.X - linkBox.Center.X;
                float TopBottomCheck = CheckSide.Center.Y - linkBox.Center.Y;

                if (LeftRightCheck < 0)
                {
                    sides.Add(ICollision.SideLeft); //maybe wrong
                }
                else if (LeftRightCheck > 0)
                {
                    sides.Add(ICollision.SideRight);
                }
                if (TopBottomCheck > 0)
                {
                    sides.Add(ICollision.SideBottom);
                }
                else if (TopBottomCheck < 0)
                {
                    sides.Add(ICollision.SideTop);
                }
            }
            return sides;
        }
    }
}
