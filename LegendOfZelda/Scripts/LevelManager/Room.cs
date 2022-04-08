using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public class Room : ILevel
    {
        private Vector2 keySpawnPos;
        private bool keySpawned = false;
        private RoomObjectEditor roomObjectEditor;
        public IRoomBackground RoomBackground { get; private set; }
        public List<IItem> Items { get; private set; } = new List<IItem>();
        public List<IEnemy> Enemies { get; private set; } = new List<IEnemy>();
        public List<IBlock> Blocks { get; private set; } = new List<IBlock>();

        public Room() { roomObjectEditor = new RoomObjectEditor(Items, Enemies, Blocks); }
        public void OpenSecretDoorUp() { roomObjectEditor.OpenSecretDoorUp(); }
        public void OpenSecretDoorDown() { roomObjectEditor.OpenSecretDoorDown(); }
        public void OpenSecretDoorLeft() { roomObjectEditor.OpenSecretDoorLeft(); }
        public void OpenSecretDoorRight() { roomObjectEditor.OpenSecretDoorRight(); }
        public void SpawnKey() { roomObjectEditor.SpawnKey(keySpawned, keySpawnPos); }
        public void AddObject(string type, string name, int xPos, int yPos, int adjacentRoom)
        {
            if (type == "Item") roomObjectEditor.AddItem(name, xPos, yPos);
            else if (type == "Block") roomObjectEditor.AddBlock(name, xPos, yPos, adjacentRoom);
            else if (type == "Enemy") roomObjectEditor.AddEnemy(name, xPos, yPos);
        }
        public void RemoveObject(string type, int index)
        {
            if (type == "Item") roomObjectEditor.RemoveItem(index);
            else if (type == "Block") roomObjectEditor.RemoveBlock(index);
            else if (type == "Enemy") roomObjectEditor.RemoveEnemy(index);
        }
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
            if (Enemies.Count == 1) keySpawnPos = Enemies[0].position;
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