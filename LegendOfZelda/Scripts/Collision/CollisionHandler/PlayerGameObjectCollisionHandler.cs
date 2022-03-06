using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    public class PlayerGameObjectCollisionHandler: ICollisionHandler
    {
        public PlayerGameObjectCollisionHandler()
        {
        }
        public void HandleCollision(ILink link, IGameObject gameObject, ICollision side)
        {
            link.HandleBlockCollision(gameObject, side);
        }
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side)
        {

        }
    }
}
