using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Collision.CollisionDetector;
using LegendOfZelda.Scripts.Collision.CollisionHandler;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZelda.Scripts.Collision
{
    public class HandlerManager
    {
        public List<ICollisionDetector> collisionDetectors;
        public List<ICollisionHandler> collisionHandlers;
        public ILevel room;
        private ILink Link;
        private List<IWeapon> activeWeapons;
        private RoomManager roomManager;
        private int gameScale = 2;


        private List<IBlock> blocks;
        private List<IItem> items;
        private List<IEnemy> enemys;

        public HandlerManager(List<ICollisionDetector> CollisionDetectors)
        {
            collisionDetectors = CollisionDetectors;

            PlayerGameObjectCollisionHandler playerBlockCollisionHandler = new PlayerGameObjectCollisionHandler();
            EnemyGameObjectCollisionHandler enemyItemCollisionHandler = new EnemyGameObjectCollisionHandler();
            PlayerEnemyCollisionHandler playerEnemyCollisionHandler = new PlayerEnemyCollisionHandler();
            PlayerDoorCollisionHandler playerDoorCollisionHandler = new PlayerDoorCollisionHandler();
            collisionHandlers = new List<ICollisionHandler>() { playerBlockCollisionHandler, enemyItemCollisionHandler, playerEnemyCollisionHandler, playerDoorCollisionHandler };
        }
        public void AssignRoom()
        {
            blocks = room.Blocks;
            items = room.Items;
            enemys = room.Enemies;
        }

        public void ForAllUpdate()
        {
            AssignRoom();
            ForLinkBlocks();
            ForLinkWeapon();
            ForLinkItem();
            ForEnemy();
        }

        public void Update(ILink link, List<IWeapon> ActiveWeapons, RoomManager RoomManager, int GameScale)
        {
            Link = link;
            activeWeapons = ActiveWeapons;
            roomManager = RoomManager;
            gameScale = GameScale;
            ForAllUpdate();
        }
        private void ForLinkBlocks()
        {
            foreach (IBlock block in blocks)
            {
                List<ICollision> sides = collisionDetectors[0].BoxTest(Link, block, gameScale);
                if (sides.Count > 0 && sides[0] != ICollision.SideNone)
                {
                    collisionHandlers[3].HandleCollision(Link, block, roomManager, gameScale);
                }
                foreach (ICollision side in sides)
                {
                    collisionHandlers[0].HandleCollision(Link, block, side, gameScale);
                }
            }
        }

        private void ForLinkWeapon() //Some weapon will hurt the link
        {
            foreach (IWeapon weapon in activeWeapons)
            {
                if (weapon.GetWeaponType() is IWeapon.WeaponType.EXPLOSION)
                {
                    List<ICollision> sides3 = collisionDetectors[0].BoxTest(Link, weapon, gameScale);
                    if (!sides3.Contains(ICollision.SideNone) && sides3.Count > 0)
                    {
                        collisionHandlers[0].HandleCollision(Link, weapon, sides3[0], gameScale);
                    }
                }
                else if (weapon.GetWeaponType() is IWeapon.WeaponType.FIRE)
                {
                    List<ICollision> sides4 = collisionDetectors[0].BoxTest(Link, weapon, gameScale);
                    if (!sides4.Contains(ICollision.SideNone) && sides4.Count > 0 && weapon.AnimationTimer > 50)
                    {
                            collisionHandlers[0].HandleCollision(Link, weapon, sides4[0], gameScale);
                    }
                }
            }
        }

        public void ForLinkItem()
        {
            int index = 0;
            List<int> indices = new List<int>(); //I mean, design the object could delete itself is more effectively.
            foreach (IItem item in items)
            {
                List<ICollision> sides = collisionDetectors[0].BoxTest(Link, item, gameScale);
                if (!sides.Contains(ICollision.SideNone))
                {
                    indices.Add(index);
                    item.PickItem(Link.State.Position);
                }

                foreach (ICollision side in sides)
                {
                    //Debug.WriteLine(index);
                    collisionHandlers[0].HandleCollision(Link, item, side, gameScale);
                }
                index++;
            }

            int delete = 0; //when the object remove, all index behind that will change.

            foreach (int ind in indices)
            {
                int actualDeleteIndex = ind - delete;
                collisionHandlers[0].HandleItemDestroy((Room)room, actualDeleteIndex);
            }
        }


        public void ForEnemy()
        {
            foreach (IEnemy enemy in enemys)
            {
                List<ICollision> sides2 = collisionDetectors[2].BoxTest(Link, enemy, gameScale);
                foreach (ICollision side in sides2)
                {
                    collisionHandlers[2].HandleCollision(Link, enemy, side);
                }
                foreach (IWeapon weapon in activeWeapons)
                {
                    if (!weapon.IsNull())
                    {
                        List<ICollision> sides = collisionDetectors[1].BoxTest(enemy, weapon, gameScale);
                        foreach (ICollision side in sides)
                        {
                            collisionHandlers[1].HandleCollision(enemy, weapon, side, gameScale);
                        }
                    }
                }
                foreach (IBlock block in blocks)
                {
                    List<ICollision> sides = collisionDetectors[1].BoxTest(enemy, block, gameScale);

                    foreach (ICollision side in sides)
                    {
                        collisionHandlers[1].HandleCollision(enemy, block, side, gameScale);
                    }
                }
            }
        }

    }


}
