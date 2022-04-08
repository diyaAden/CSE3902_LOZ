using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Blocks.BlockSprites;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class RoomObjectEditor
    {
        private bool keySpawned = false, crackedDoorsOpened = false;
        public List<IItem> Items { get; private set; } 
        public List<IEnemy> Enemies { get; private set; }
        public List<IBlock> Blocks { get; private set; }
        public RoomObjectEditor(List<IItem> items, List<IEnemy> enemies, List<IBlock> blocks) 
        {
            Items = items;
            Enemies = enemies;
            Blocks = blocks;
        }
        public void OpenSecretDoorUp()
        {
            foreach (IBlock block in Blocks)
            {
                if (block is SecretWallUpSprite) block.Disable();
            }
        }
        public void OpenSecretDoorDown()
        {
            foreach (IBlock block in Blocks)
            {
                if (block is SecretWallDownSprite) block.Disable();
            }
        }
        public void OpenSecretDoorLeft()
        {
            foreach (IBlock block in Blocks)
            {
                if (block is SecretWallLeftSprite) block.Disable();
            }
        }
        public void OpenSecretDoorRight()
        {
            foreach (IBlock block in Blocks)
            {
                if (block is SecretWallRightSprite) block.Disable();
            }
        }
        public void OpenCrackedDoors()
        {
            if (!crackedDoorsOpened) {
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
        public void RemoveEnemy(int index) { Enemies.RemoveAt(index); }
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
    }
}
