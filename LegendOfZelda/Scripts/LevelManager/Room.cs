using LegendOfZelda.Scripts.Blocks;
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
        public IRoomBackground roomBackground;
        public List<IItem> Items { get; private set; }
        public List<IEnemy> Enemies { get; private set; }
        public List<IBlock> Blocks { get; private set; }

        public Room()
        {
            Items = new List<IItem>();
            Enemies = new List<IEnemy>();
            Blocks = new List<IBlock>();
        }

        public void AddObject(string type, string name, int xPos, int yPos, int adjacentRoom)
        {
            if (type == "Item") AddItem(name, xPos, yPos);
            else if (type == "Block") AddBlock(name, xPos, yPos, adjacentRoom);
            else if (type == "Enemy") AddEnemy(name, xPos, yPos);
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
            Blocks[^1].position = new Vector2(xPos, yPos);
            if (name.Contains("Door")) {
                Blocks[^1].adjacentRoom = adjacentRoom;
            }

        }
        private void AddEnemy(string name, int xPos, int yPos)
        {
            Enemies.Add(EnemySpriteFactory.Instance.CreateEnemyFromString(name));
            Enemies[^1].position = new Vector2(xPos, yPos);
        }
        public void AddRoomBackground(int roomNumber)
        {
            roomBackground = RoomBackgroundFactory.Instance.CreateFromRoomNumber(roomNumber);
        }

        public void Update(int scale)
        {
            foreach (IItem item in Items) item.Update();
            foreach (IBlock block in Blocks) block.Update();
            foreach (IEnemy enemy in Enemies) enemy.Update(scale);
        }

        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            roomBackground.Draw(spriteBatch, scale);
            foreach (IItem item in Items) item.Draw(spriteBatch, scale);
            foreach (IBlock block in Blocks) block.Draw(spriteBatch, scale);
            foreach (IEnemy enemy in Enemies) enemy.Draw(spriteBatch, scale);
        }
    }
}