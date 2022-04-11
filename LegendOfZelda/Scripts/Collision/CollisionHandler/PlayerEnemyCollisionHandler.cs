using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Enemy.WallMaster.Sprite;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    class PlayerEnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ILink link, IEnemy enemy, ICollision side, int scale, Vector2 screenOffset, int index)
        {
            if (enemy is BasicWallMasterSprite)
            {

                if (link.CatchByEnemy == index)
                {
                    link.HandleEnemyCollision(enemy);
                    enemy.HandleCollision(side, scale, screenOffset);

                }
                else if (link.CatchByEnemy == -1 && !(side == ICollision.SideNone))
                {
                    link.MoveDown();
                    link.ToIdle();
                    link.CatchByEnemy = index;
                    link.HandleEnemyCollision(enemy);
                    Debug.WriteLine(link.CatchByEnemy);
                }
                else
                {
                    link.HandleEnemyCollision(enemy, side);
                }

            }
        }
        public void HandleCollision(ILink link, IGameObject gameObject, ICollision side, int scale)
        {

        }
        public void HandleCollision(IEnemy enemy, IGameObject gameObject, ICollision side, int scale)
        {

        }
        public void HandleCollision(ILink link, IBlock door, RoomManager roomManager, int scale) { }
        public void HandleItemDestroy(Room CurrentRoom, int index) { }
        public void HandleEnemyDestroy(Room CurrentRoom, int index) { }
    }
}


