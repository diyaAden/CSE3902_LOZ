using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room
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

        public void AddObject(string type, string name, int xPos, int yPos)
        {
            if (type == "Item") AddItem(name, xPos, yPos);
            else if (type == "Block") AddBlock(name, xPos, yPos);
            else if (type == "Enemy") AddEnemy(name, xPos, yPos);
        }
        private void AddItem(string name, int xPos, int yPos)
        {
            Items.Add(ItemSpriteFactory.Instance.CreateItemFromString(name));
            Items[^1].position = new Vector2(xPos, yPos);
        }
        private void AddBlock(string name, int xPos, int yPos)
        {
            Blocks.Add(BlockSpriteFactory.Instance.CreateBlockFromString(name));
            Blocks[^1].position = new Vector2(xPos, yPos);
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

        public void Update()
        {
            foreach (IItem item in Items) item.Update();
            foreach (IBlock block in Blocks) block.Update();
            foreach (IEnemy enemy in Enemies) enemy.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            roomBackground.Draw(spriteBatch);
            foreach (IItem item in Items) item.Draw(spriteBatch);
            foreach (IBlock block in Blocks) block.Draw(spriteBatch);
            foreach (IEnemy enemy in Enemies) enemy.Draw(spriteBatch);
        }
    }
}
