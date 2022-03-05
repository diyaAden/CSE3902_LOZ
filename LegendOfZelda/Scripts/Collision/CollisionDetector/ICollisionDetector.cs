﻿
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionDetector
{
    public interface ICollisionDetector
    {
        List<ICollision> BoxTest(ILink link, IGameObject gameObject);
    }
}
