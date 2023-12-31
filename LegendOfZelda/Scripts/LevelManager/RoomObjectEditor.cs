﻿using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Blocks.BlockSprites;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Enemy.Goriya;
using LegendOfZelda.Scripts.Enemy.WallMaster.Sprite;
using LegendOfZelda.Scripts.Enemy.Zapdos.Sprite;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomObjectEditor
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT }
        private const int enemyDropItemProb = 6;
        private bool keySpawned = false, crackedDoorsOpened = false, heartContainerSpawned = false, boomerangSpawned = false;
        private Random rnd = new Random();
        public List<IItem> Items { get; private set; }
        public List<IEnemy> Enemies { get; private set; }
        public List<IBlock> Blocks { get; private set; }
        public RoomObjectEditor(List<IItem> items, List<IEnemy> enemies, List<IBlock> blocks)
        {
            Items = items;
            Enemies = enemies;
            Blocks = blocks;
        }
        public void OpenSecretDoor(Direction direction)
        {
            foreach (IBlock block in Blocks)
            {
                if (direction == Direction.UP && block is SecretWallUpSprite) block.Disable();
                else if (direction == Direction.DOWN && block is SecretWallDownSprite) block.Disable();
                else if (direction == Direction.LEFT && block is SecretWallLeftSprite) block.Disable();
                else if (direction == Direction.RIGHT && block is SecretWallRightSprite) block.Disable();
            }
        }
        public void OpenCrackedDoors()
        {
            if (!crackedDoorsOpened)
            {
                foreach (IBlock block in Blocks)
                {
                    if (block is CrackedDoorSpriteRight || block is CrackedDoorSpriteLeft || block is CrackedDoorSpriteUp || block is CrackedDoorSpriteDown)
                        block.Disable();
                    crackedDoorsOpened = true;
                }
            }
        }
        public void AddItem(string name, int xPos, int yPos)
        {
            Items.Add(ItemSpriteFactory.Instance.CreateItemFromString(name));
            Items[^1].Position = new Vector2(xPos, yPos);
        }
        public void AddBlock(string name, int xPos, int yPos, int adjacentRoom)
        {
            Blocks.Add(BlockSpriteFactory.Instance.CreateBlockFromString(name));
            Blocks[^1].Position = new Vector2(xPos, yPos);
            if (name.Contains("Door") || name.Contains("Stairs"))
            {
                Blocks[^1].AdjacentRoom = adjacentRoom;
            }
        }
        public void AddEnemy(string name, int xPos, int yPos)
        {
            Enemies.Add(EnemySpriteFactory.Instance.CreateEnemyFromString(name));
            Enemies[^1].position = new Vector2(xPos, yPos);
        }
        public void RemoveItem(int index) { Items.RemoveAt(index); }
        public void RemoveBlock(int index) { }
        private bool IsNormalEnemy(IEnemy enemy)
        {
            return !(enemy is BasicExplosionSprite || enemy is BasicCloudSprite || enemy is BasicFireballSprite || enemy is BoomerangEnemy);
        }
        private bool isPokemon(IEnemy enemy) {
            return (enemy is BasicCharizardSprite || enemy is BasicZapdosSprite);
        }

        public void RemoveEnemy(int index)
        {
            int itemSpawnChance;
            if (IsNormalEnemy(Enemies[index]))
            {
                Vector2 enemyPos = Enemies[index].position;
                if (isPokemon(Enemies[index]))
                {
                    itemSpawnChance = rnd.Next(0, 1);
                }else itemSpawnChance = rnd.Next(0, enemyDropItemProb);
                if (itemSpawnChance == 0)
                {
                    IItem heart = ItemSpriteFactory.Instance.CreateHeartSprite();
                    heart.Position = enemyPos;
                    Items.Add(heart);
                }
                else if (itemSpawnChance == 1)
                {
                    IItem rupee = ItemSpriteFactory.Instance.CreateRupeeSprite();
                    rupee.Position = enemyPos;
                    Items.Add(rupee);
                }
                SpawnEnemyExplosion(index, enemyPos);
               
            }
            Enemies.RemoveAt(index);
        }
        public void SpawnEnemyExplosion(int index, Vector2 enemyPos)
        {
            IEnemy explosion;
            if (Enemies[index] is BasicAquamentusSprite) explosion = EnemySpriteFactory.Instance.CreateCloudSprite();
            else explosion = EnemySpriteFactory.Instance.CreateExplosionSprite();
            explosion.position = enemyPos;
            Enemies.Add(explosion);
        }
        public void SpawnKey(Vector2 keySpawnPos)
        {
            if (!keySpawned)
            {
                IItem key = ItemSpriteFactory.Instance.CreateKeySprite();
                key.Position = keySpawnPos;
                Items.Add(key);
                keySpawned = true;
            }
        }
        public void SpawnHeartContainer(int scale, Vector2 screenOffset)
        {
            if (!heartContainerSpawned)
            {
                IItem container = ItemSpriteFactory.Instance.CreateHeartContainerSprite();
                container.Position = new Vector2((209 + screenOffset.X) * scale, (81 + screenOffset.Y) * scale);
                Items.Add(container);
                heartContainerSpawned = true;
            }
        }
        public void SpawnBoomerang(int scale, Vector2 screenOffset)
        {
            if (!boomerangSpawned)
            {
                IItem boomerang = ItemSpriteFactory.Instance.CreateWoodBoomerangItemSprite();
                boomerang.Position = new Vector2((115 + screenOffset.X) * scale, (83 + screenOffset.Y) * scale);
                Items.Add(boomerang);
                boomerangSpawned = true;
            }
        }
        public void UpdateEnemyWithProjectiles(IEnemy enemy, Vector2 linkPosition, int scale, Vector2 screenOffset)
        {
            if (enemy is BasicAquamentusSprite dragon)
                dragon.Update(Enemies, scale, screenOffset);
            else if(enemy is BasicCharizardSprite charizard) {
                charizard.Update(Enemies, scale, screenOffset);
            }
            else if (enemy is BasicGoriyaSprite goriya)
                goriya.Update(Enemies, scale, screenOffset);
            else if (enemy is BasicDarknutSprite darknut)
                darknut.Update(Enemies, scale, screenOffset, linkPosition);

        }

        public void UpdateEnemyToWall(IEnemy enemy, int scale, Vector2 screenOffset, bool isCollisionWithLink)
        {
            if (enemy is BasicWallMasterSprite wallMaster)
                wallMaster.Update(isCollisionWithLink, scale, screenOffset);
        }
    }
}