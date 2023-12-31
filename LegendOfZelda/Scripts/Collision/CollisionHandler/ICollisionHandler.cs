﻿using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    public interface ICollisionHandler
    {
        void HandleCollision(ILink link, IGameObject gameObject, ICollision side, int scale);
        void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side, int scale);

        void HandleCollision(ILink link, IEnemy enemy, ICollision side, int scale, Vector2 screenOffset, int index, RoomManager roomManager);

        public void HandleCollision(ILink link, IBlock door, RoomManager roomManager, int scale);
        public void HandleItemDestroy(Room CurrentRoom, int index);
        public void HandleEnemyDestroy(Room CurrentRoom, int index);
    }
}
