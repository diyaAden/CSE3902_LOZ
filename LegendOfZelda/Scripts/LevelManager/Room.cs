using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Blocks.BlockSprites;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room : ILevel
    {
        public IRoomBackground RoomBackground { get; private set; }
        public List<IItem> Items { get; private set; } = new List<IItem>();
        public List<IEnemy> Enemies { get; private set; } = new List<IEnemy>();
        public List<IBlock> Blocks { get; private set; } = new List<IBlock>();

        public Room() { }
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
        public void AddObject(string type, string name, int xPos, int yPos, int adjacentRoom)
        {
            if (type == "Item") AddItem(name, xPos, yPos);
            else if (type == "Block") AddBlock(name, xPos, yPos, adjacentRoom);
            else if (type == "Enemy") AddEnemy(name, xPos, yPos);
        }
        public void RemoveObject(string type, int index)
        {
            if (type == "Item") RemoveItem(index);
            else if (type == "Block") RemoveBlock(index);
            else if (type == "Enemy") RemoveEnemy(index);
        }
        private void AddItem(string name, int xPos, int yPos)
        {
            Items.Add(ItemSpriteFactory.Instance.CreateItemFromString(name));
            Items[^1].Position = new Vector2(xPos, yPos);
        }
        private void AddBlock(string name, int xPos, int yPos, int adjacentRoom)
        {
            Blocks.Add(BlockSpriteFactory.Instance.CreateBlockFromString(name));
            Debug.WriteLine(Blocks[^1]);
            Blocks[^1].Position = new Vector2(xPos, yPos);
            if (name.Contains("Door") || name.Contains("Stairs")) {
                Blocks[^1].AdjacentRoom = adjacentRoom;
            }

        }
        private void AddEnemy(string name, int xPos, int yPos)
        {
            Enemies.Add(EnemySpriteFactory.Instance.CreateEnemyFromString(name));
            Enemies[^1].position = new Vector2(xPos, yPos);
        }
        private void RemoveItem(int index)
        {
            Debug.WriteLine("Remove" + index);
            Items.RemoveAt(index);
        }
        private void RemoveBlock(int index) { }
        private void RemoveEnemy(int index) { Enemies.RemoveAt(index); }
        public void AddRoomBackground(int roomNumber, Vector2 screenOffset, int scale)
        {
            RoomBackground = RoomBackgroundFactory.Instance.CreateFromRoomNumber(roomNumber);
            RoomBackground.Position = new Vector2((RoomBackground.Position.X + screenOffset.X) * scale, (RoomBackground.Position.Y + screenOffset.Y) * scale);
        }
        public void Update(Vector2 linkPosition, int scale, Vector2 screenOffset)
        {
            foreach (IItem item in Items) item.Update();
            foreach (IBlock block in Blocks) block.Update();
            foreach (IEnemy enemy in Enemies) enemy.Update(linkPosition, scale, screenOffset);
        }
        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            DrawBackgroundAndBlocks(spriteBatch, scale);
            foreach (IEnemy enemy in Enemies) enemy.Draw(spriteBatch, scale);
            foreach (IItem item in Items) item.Draw(spriteBatch, scale);
        }
        public void DrawBackgroundAndBlocks(SpriteBatch spriteBatch, int scale)
        {
            RoomBackground.Draw(spriteBatch, scale);
            foreach (IBlock block in Blocks) block.Draw(spriteBatch, scale);
        }
        public void ShiftRoom(int distX, int distY, int scale)
        {
            RoomBackground.Position = new Vector2(RoomBackground.Position.X + distX * scale, RoomBackground.Position.Y + distY * scale);
            foreach (IBlock block in Blocks)
            {
                block.Position = new Vector2(block.Position.X + distX * scale, block.Position.Y + distY * scale);
            }
        }
    }
}