using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Enemy.WallMaster.Sprite;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LegendOfZelda.Scripts.Collision.CollisionHandler
{
    class PlayerEnemyCollisionHandler: ICollisionHandler
    {
        public void HandleCollision(ILink link, IEnemy enemy, ICollision side, int scale, Vector2 screenOffset, int index, RoomManager roomManager)
        {
            if (enemy is BasicWallMasterSprite)
            {
                if (link.CatchByEnemy == index)
                {
                    enemy.HandleCollision(side, scale, screenOffset, link.CatchByEnemy);
                    link.HandleEnemyCollision(enemy, scale);
                    //Debug.WriteLine("why not come" + index);
                    if (enemy.IsCollisionWithLink == false)
                    {
                        roomManager.CurrentRoom = 2;
                        link.State.SetPosition(new Vector2(400, 350));
                        link.Update();
                        link.CatchByEnemy = -1;
                        //Debug.WriteLine("change" + index);                        
                    }
                }
                else if (link.CatchByEnemy == -1 && !(side == ICollision.SideNone))
                {
                    link.MoveDown();
                    link.ToIdle();
                    link.CatchByEnemy = index;
                    link.HandleEnemyCollision(enemy, scale);
                    //Debug.WriteLine(link.CatchByEnemy + "  " + index);
                }
                else
                {
                    link.HandleEnemyCollision(enemy, side);
                }
            }
            else
            {
                link.HandleEnemyCollision(enemy, side);
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
