using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.Collision.CollisionDetector
{
    class CollisionWeaponGameObjectDetector: ICollisionDetector
    {
        public List<ICollision> BoxTest(ILink link, IEnemy enemy, int scale)
        {
            return null;
        }
        public List<ICollision> BoxTest(ILink link, IGameObject gameObject, int scale)
        {
            return null;
        }
        public List<ICollision> BoxTest(IWeapon weapon, IGameObject gameObject, int scale)
        {
            List<ICollision> sides = new List<ICollision>();
            Rectangle weaponBox = weapon.ObjectBox(scale);
            Rectangle objectBox = gameObject.ObjectBox(scale);
            Rectangle CheckSide = Rectangle.Intersect(weaponBox, objectBox);
            if (CheckSide.IsEmpty)
            {
                sides.Add(ICollision.SideNone);
            }
            else
            {
                float LeftRightCheck = CheckSide.Center.X - objectBox.Center.X;
                float TopBottomCheck = CheckSide.Center.Y - objectBox.Center.Y;

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

        public List<ICollision> BoxTest(IEnemy link, IGameObject gameObject, int scale)
        {
            return null;
        }
    }
}
