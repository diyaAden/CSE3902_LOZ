﻿using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Blocks.BlockSprites;
using LegendOfZelda.Scripts.Collision.CollisionDetector;
using LegendOfZelda.Scripts.Collision.CollisionHandler;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.GameStateMachine;
using LegendOfZelda.Scripts.Items;
using LegendOfZelda.Scripts.Items.WeaponCreators;
using LegendOfZelda.Scripts.LevelManager;
using LegendOfZelda.Scripts.Links;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using LegendOfZelda.Scripts.Achievement;
using LegendOfZelda.Scripts.Enemy.WallMaster.Sprite;
using LegendOfZelda.Scripts.Items.ItemSprites;
using LegendOfZelda.Scripts.Enemy.Gel.Sprite;

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
        public RoomMovingController roomMovingController;
        public AchievementCollection achievementCollection;
        private int gameScale = 2;


        private List<IBlock> blocks;
        private List<IItem> items;
        private List<IEnemy> enemies;

        public HandlerManager(List<ICollisionDetector> CollisionDetectors, RoomMovingController roomMovingController, AchievementCollection achievementCollection)
        {
            collisionDetectors = CollisionDetectors;
            this.roomMovingController = roomMovingController;
            this.achievementCollection = achievementCollection;
            PlayerGameObjectCollisionHandler playerBlockCollisionHandler = new PlayerGameObjectCollisionHandler();
            EnemyGameObjectCollisionHandler enemyItemCollisionHandler = new EnemyGameObjectCollisionHandler();
            PlayerEnemyCollisionHandler playerEnemyCollisionHandler = new PlayerEnemyCollisionHandler();
            PlayerDoorCollisionHandler playerDoorCollisionHandler = new PlayerDoorCollisionHandler();
            BombWallCollisionHandler bombWallCollisionHandler = new BombWallCollisionHandler();
            collisionHandlers = new List<ICollisionHandler>() { playerBlockCollisionHandler, enemyItemCollisionHandler, playerEnemyCollisionHandler, playerDoorCollisionHandler, bombWallCollisionHandler };
        }
        public void AssignRoom()
        {
            blocks = room.Blocks;
            items = room.Items;
            enemies = room.Enemies;
        }

        public void ForAllUpdate(Vector2 screenOffset)
        {
            AssignRoom();
            if (Link.CatchByEnemy == -1)
            {
                ForLinkWeapon();
                ForLinkItem();
                ForLinkBlocks();
            }
            ForEnemy(screenOffset);
            ForWeaponObject();
        }

        public void Update(ILink link, List<IWeapon> ActiveWeapons, RoomManager RoomManager, int GameScale, Vector2 screenOffset)
        {
            Link = link;
            activeWeapons = ActiveWeapons;
            roomManager = RoomManager;
            gameScale = GameScale;
            ForAllUpdate(screenOffset);
            triggerRoomAchivement();
        }

        public void triggerRoomAchivement()
        {
            switch (roomManager.CurrentRoom)
            {
                case 8:
                    achievementCollection.changeCurrentAchievement(2);
                    break;
                default:
                    break;
            }
        }
        public void ForWeaponObject()
        {
            foreach (IWeapon weapon in activeWeapons)
            {
                bool setToDestroy = false;
                foreach (IBlock block in blocks)
                {
                    List<ICollision> sides = collisionDetectors[3].BoxTest(weapon, block, gameScale);
                    if (sides.Count > 0 && sides[0] != ICollision.SideNone && !(block is BlueGapSprite))
                    {
                        setToDestroy = true;
                        if (weapon is BombWeapon bomb && bomb.DetonatingNow()) 
                            collisionHandlers[4].HandleCollision(Link, block, roomManager, gameScale);
                            if(block is BombedDoorSpriteDown|| block is BombedDoorSpriteUp || block is BombedDoorSpriteLeft || block is BombedDoorSpriteRight)
                                achievementCollection.changeCurrentAchievement(9);
                    }
                }
                foreach (IEnemy enemy in enemies)
                {
                    List<ICollision> sides = collisionDetectors[3].BoxTest(weapon, enemy, gameScale);
                    if (sides.Count > 0 && sides[0] != ICollision.SideNone)
                    {
                        setToDestroy = true;
                        if (weapon is BombWeapon bomb && bomb.DetonatingNow()) //Actually want to have a fire but not find
                            achievementCollection.changeCurrentAchievement(1);
                    }
                }
                if (setToDestroy) weapon.DestroyWeapon(gameScale);
            }
        }
        public void ForLinkBlocks()
        {
            foreach (IBlock block in blocks)
            {
                List<ICollision> sides = collisionDetectors[0].BoxTest(Link, block, gameScale);
                if (sides.Count > 0 && sides[0] != ICollision.SideNone && !Link.BeingPushed)
                {
                    ((PlayerDoorCollisionHandler)collisionHandlers[3]).HandleCollision(Link, block, roomMovingController, gameScale);
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
                if (!sides.Contains(ICollision.SideNone) && sides.Count > 0)
                {

                    achievementCollection.changeCurrentAchievement(3);

                    indices.Add(index);
                    collisionHandlers[0].HandleCollision(Link, item, sides[0], gameScale);
                }
                index++;
            }

            int delete = 0; //when the object remove, all index behind that will change.

            foreach (int ind in indices)
            {
                int actualDeleteIndex = ind - delete;
                collisionHandlers[0].HandleItemDestroy((Room)room, actualDeleteIndex);
                delete++;
            }
        }


        public void ForEnemy(Vector2 screenOffset)
        {
            int index = 0;
            List<int> indices = new List<int>();

            foreach (IEnemy enemy in enemies)
            {
                List<ICollision> sides2 = collisionDetectors[2].BoxTest(Link, enemy, gameScale);
                if (!sides2.Contains(ICollision.SideNone) && sides2.Count > 0)
                {
                    if (enemy is BasicWallMasterSprite)
                        achievementCollection.changeCurrentAchievement(4);
                    if (enemy is BasicGelSprite)
                        achievementCollection.changeCurrentAchievement(8);
                }
                foreach (ICollision side in sides2)
                {
                    collisionHandlers[2].HandleCollision(Link, enemy, side, gameScale, screenOffset, index, roomManager);
                    
                }
                foreach (IWeapon weapon in activeWeapons)
                {
                    if (!weapon.IsNull())
                    {
                        List<ICollision> sides = collisionDetectors[1].BoxTest(enemy, weapon, gameScale);
                        if (!sides.Contains(ICollision.SideNone) && sides.Count > 0 && enemy.Health <= 0)
                        {
                            if (!indices.Contains(index)) indices.Add(index);
                        }
                        foreach (ICollision side in sides)
                        {
                            if (weapon.GetWeaponType() != IWeapon.WeaponType.BOMB)
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
                if (enemy.Health == 0 && !indices.Contains(index))
                    indices.Add(index);
                index++;
            }
            int delete = 0; //when the object remove, all index behind that will change.

            foreach (int ind in indices)
            {
                int actualDeleteIndex = ind - delete;
                if(room.Enemies[actualDeleteIndex] is BasicAquamentusSprite)
                    achievementCollection.changeCurrentAchievement(5);
                collisionHandlers[1].HandleEnemyDestroy((Room)room, actualDeleteIndex);
                delete++;
            }
        }

    }


}
