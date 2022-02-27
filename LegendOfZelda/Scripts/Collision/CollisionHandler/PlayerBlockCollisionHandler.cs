using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Collision.CollisionType;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    public class PlayerBlockCollisionHandler: ICollisionHandler
    {
        public PlayerBlockCollisionHandler()
        {
        }
        public void HandleCollision(ILink link, IGameObject block, ICollision side)
        {
            link.HandleBlockCollision(block, side);
        }
    }
}
