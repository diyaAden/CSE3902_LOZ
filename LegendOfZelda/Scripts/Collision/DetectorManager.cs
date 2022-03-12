using LegendOfZelda.Scripts.Collision.CollisionDetector;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision
{
    public class DetectorManager
    {
        public List<ICollisionDetector> collisionDetectors;
        public DetectorManager()
        {
            CollisionPlayerGameObjectDetector collisionPlayerBlockDetector = new CollisionPlayerGameObjectDetector();
            CollisionEnemyGameObjectDetector collisionEnemyItemDetector = new CollisionEnemyGameObjectDetector();
            CollisionPlayerEnemyDetector collisionPlayerEnemyDetector = new CollisionPlayerEnemyDetector();
            collisionDetectors = new List<ICollisionDetector>() { collisionPlayerBlockDetector, collisionEnemyItemDetector, collisionPlayerEnemyDetector };
        }


    }
}
