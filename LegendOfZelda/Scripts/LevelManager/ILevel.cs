﻿using LegendOfZelda.Scripts.Blocks;
using LegendOfZelda.Scripts.Enemy;
using LegendOfZelda.Scripts.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Scripts.LevelManager
{
    public interface ILevel
    {
        public List<IItem> Items { get; }
        public List<IEnemy> Enemies { get; }
        public List<IBlock> Blocks { get; }

        public void AddObject(string type, string name, int xPos, int yPos);
        public void AddRoomBackground(int roomNumber);
        public void Update();
        public void Draw(SpriteBatch spriteBatch, int scale);
    }
}