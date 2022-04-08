using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public interface ILevel
    {
        public IRoomBackground RoomBackground { get; }
        public List<IItem> Items { get; }
        public List<IEnemy> Enemies { get; }
        public List<IBlock> Blocks { get; }

        public void AddObject(string type, string name, int xPos, int yPos, int adjacentRoom);
        public void Update(Vector2 linkPosition, int scale, Vector2 screenOffset);
        public void AddRoomBackground(int roomNumber, Vector2 screenOffset, int scale);
        public void Draw(SpriteBatch spriteBatch, int scale);
        public void OpenSecretDoor(RoomObjectEditor.Direction direction);
        public void OpenCrackedDoors();
        public void SpawnKey();
        public void SpawnHeartContainer();
        public void DrawBackgroundAndBlocks(SpriteBatch spriteBatch, int scale);
    }
}