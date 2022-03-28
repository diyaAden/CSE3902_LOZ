using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Collision.CollisionDetector
{
    class CollisionPlayerGameObjectDetector: ICollisionDetector
    {
        private int collisionDetectionRange = 8;

        public List<ICollision> BoxTest(IEnemy enemy, IGameObject gameObject, int scale)
        {
            return null;
        }
        public List<ICollision> BoxTest(ILink link, IGameObject gameObject, int scale)
        {
            List<ICollision> sides = new List<ICollision>();
            Rectangle linkBox = link.State.LinkBox(scale);
            Rectangle CheckSide = Rectangle.Intersect(linkBox, gameObject.ObjectBox(scale));
            if (CheckSide.IsEmpty)
            {
                sides.Add(ICollision.SideNone);
            }
            else
            {
                float LeftRightCheck = CheckSide.Center.X - linkBox.Center.X;
                float TopBottomCheck = CheckSide.Center.Y - linkBox.Center.Y;
                
                if (LeftRightCheck < -collisionDetectionRange)
                {
                    sides.Add(ICollision.SideLeft); //maybe wrong
                }else if(LeftRightCheck > collisionDetectionRange)
                {
                    sides.Add(ICollision.SideRight);
                }
                if(TopBottomCheck > collisionDetectionRange)
                {
                    sides.Add(ICollision.SideBottom);
                }
                else if (TopBottomCheck < -collisionDetectionRange)
                {
                    sides.Add(ICollision.SideTop);
                }
            }
            return sides;
        }

        public List<ICollision> BoxTest(ILink link, IEnemy enemy, int scale)
        {
            return null;
        }
    }
}
