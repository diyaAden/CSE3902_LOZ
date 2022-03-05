
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionDetector
{
    class CollisionPlayerBlockDetector: ICollisionDetector
    {
        public List<ICollision> BoxTest(ILink link, IGameObject gameObject)
        {
            List<ICollision> sides = new List<ICollision>();
            Rectangle linkBox = link.State.LinkBox();
            Rectangle CheckSide = Rectangle.Intersect(linkBox, gameObject.ObjectBox());
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
                }else if(LeftRightCheck > 0)
                {
                    sides.Add(ICollision.SideRight);
                }
                if(TopBottomCheck > 0)
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
